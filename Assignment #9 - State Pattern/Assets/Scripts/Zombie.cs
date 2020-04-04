/*
 * Kevon Long
 * Zombie.cs
 * Assignment #9
 * Tries to kill the player
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Rigidbody2D rb;
    public Player player;
    private Vector2 movement;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * 2.0f * Time.deltaTime));
    }
}
