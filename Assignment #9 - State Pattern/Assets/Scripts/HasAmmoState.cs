/*
 * Kevon Long
 * HasAmmoState.cs
 * Assignment #9
 * One of the states for the gun when it has ammo
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasAmmoState : IGunStates
{
    Player playerWithGun;

    public HasAmmoState(Player playerWithGun)
    {
        this.playerWithGun = playerWithGun;
    }

    public void PickUpAmmo()
    {
        playerWithGun.gotAmmoPack();
    }

    public void ShootGun()
    {
        playerWithGun.ShootBullet();
        if(playerWithGun.GetAmmoCount() > 0)
        {
            playerWithGun.SetState(playerWithGun.getHasAmmoState());
        }
        else
        {
            playerWithGun.SetState(playerWithGun.getNoAmmoState());
        }
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
