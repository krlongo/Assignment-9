/*
 * Kevon Long
 * NoAmmoState.cs
 * Assignment #9
 * One of the states for the gun when it has no ammo
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAmmoState : IGunStates
{
    Player playerWithGun;

    public NoAmmoState(Player playerWithGun)
    {
        this.playerWithGun = playerWithGun;
    }

    public void PickUpAmmo()
    {
        playerWithGun.gotAmmoPack();
        playerWithGun.SetState(playerWithGun.getHasAmmoState());
    }

    public void ShootGun()
    {
        Debug.Log("No ammo!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
