/*
 * Kevon Long
 * Player.cs
 * Assignment #9
 * Lets you control the players movements and the gun behaviors since they act as one
 * */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public Bullet bulletprefab;
    float dirX, dirY;
    public static Vector2 moveDirection;

    public static int numOfEnemiesLeft = 20;
    public Text enemiesLefttext;
    
    IGunStates hasAmmoState;
    IGunStates noAmmoState;

    IGunStates state;
    public int ammoCount = 5;
    public Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount = 5;
        numOfEnemiesLeft = 20;
        rb = GetComponent<Rigidbody2D>();
        hasAmmoState = new HasAmmoState(this);
        noAmmoState = new NoAmmoState(this);
        if (ammoCount > 0)
        {
            state = hasAmmoState;
        }
        else {
            state = noAmmoState;
        }
    }

    public void PickUpAmmo()
    {
        state.PickUpAmmo();
    }
    public void ShootGun()
    {
        state.ShootGun();
    }

    public void SetState(IGunStates state)
    {
        this.state = state;
    }
    
    public IGunStates getHasAmmoState()
    {
        return hasAmmoState;
    }
    public IGunStates getNoAmmoState()
    {
        return noAmmoState;
    }

    public void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection = new Vector2(-10.0f, 0.0f);
            Instantiate(bulletprefab, gameObject.transform.position, gameObject.transform.rotation);
            ammoCount -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection = new Vector2(10.0f, 0.0f);
            Instantiate(bulletprefab, gameObject.transform.position, gameObject.transform.rotation);
            ammoCount -= 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = new Vector2(0.0f, 10.0f);
            Instantiate(bulletprefab, gameObject.transform.position, gameObject.transform.rotation);
            ammoCount -= 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = new Vector2(0.0f, -10.0f);
            Instantiate(bulletprefab, gameObject.transform.position, gameObject.transform.rotation);
            ammoCount -= 1;
        }
    }

    public void gotAmmoPack()
    {
        ammoCount += 5;
    }

    public int GetAmmoCount()
    {
        return ammoCount;
    }



    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * 10f;
        dirY = Input.GetAxis("Vertical") * 10f;

        ammoText.text = "Ammo Count: " + ammoCount;
        enemiesLefttext.text = "Zombies left to kill: " + numOfEnemiesLeft;

        if(numOfEnemiesLeft <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
        ShootGun();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ammo")
        {
            state.PickUpAmmo();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
