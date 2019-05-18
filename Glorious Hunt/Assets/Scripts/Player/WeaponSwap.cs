using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour {

    [SerializeField] private GameObject primary;
    [SerializeField] private GameObject secondary;

    private bool primaryA;
    private float pressDelay;
    private float pDValue;
    private GameObject newWeap;
    void Start ()
    {
        pressDelay = 1f;
        pDValue = pressDelay;

        if (primary.activeSelf)
            primaryA = true;
        else
            primaryA = false;

	}


	void Update ()
    {
        pressDelay += Time.deltaTime;

        if ((Input.GetAxisRaw("Mouse ScrollWheel") != 0 || Input.GetKeyDown(KeyCode.Alpha2)) && pressDelay >= pDValue && !ChargeGun.shooting)
        {
            Swapweapon();
        }
    }


    void Swapweapon()
    {
        primary.SetActive(false);
        secondary.SetActive(false);

        if (primaryA)
        {
            secondary.SetActive(true);
            primaryA = !primaryA;

        }
        else
        {
            primary.SetActive(true);
            primaryA = !primaryA;
        }


        pressDelay = 0;
    }

}
