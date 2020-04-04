/*
 * Kevon Long
 * IGunStates.cs
 * Assignment #9
 * Holds the methods that the gun states will determine for the context class
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGunStates
{
    void PickUpAmmo();
    void ShootGun();
}
