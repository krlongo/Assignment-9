/*
 * Kevon Long
 * Spawner.cs
 * Assignment #9
 * Spawns enemies
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Zombie zombie;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3.0f)
        {
            timer = 0f;
            Instantiate(zombie, gameObject.transform.position, gameObject.transform.rotation);
        }
    }



}
