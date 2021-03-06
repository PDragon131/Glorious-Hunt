﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombClear : MonoBehaviour
{

    public GameObject bomb;
    public GameObject bombVFX;
    public GameObject iFrameVFX;
    public static int ammo;

    private bool noSpam;

    void Start()
    {
        ammo = 4;
        noSpam = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0 && !noSpam)
        {
            StartCoroutine(Bomb());
            noSpam = true;
                
        }

        if(Player.iFrames < 2)
        {
            iFrameVFX.SetActive(true);
        }
        else
            iFrameVFX.SetActive(false);
    }

    IEnumerator Bomb()
    {
        Player.iFrames = 0;
        bomb.SetActive(true);
        bombVFX.SetActive(true);
        ammo--;
        yield return new WaitForSeconds(1.3f);
        bomb.SetActive(false);
        bombVFX.SetActive(false);
        noSpam = false;
    }

}
