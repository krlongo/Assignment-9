/*
 * Kevon Long
 * SceneChanger.cs
 * Assignment #9
 * switches scenes from the start, game, and lose scenes
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
