/*
 * Kevon Long
 * Bullet.cs
 * Assignment #9
 * Behavior for the bullets that shoot at the enemy, killing them if it hits
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Player.moveDirection;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            Player.numOfEnemiesLeft -= 1;
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
    }
}
