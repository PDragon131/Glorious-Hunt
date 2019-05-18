using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour {

    public static List<GameObject> weaponList = new List<GameObject>();

    void Start ()
    {
        DontDestroyOnLoad(this);

        Object[] tempWeaponList = Resources.LoadAll("Weapons", typeof(GameObject));

        foreach(GameObject weapon in tempWeaponList)
        {
            GameObject weap = (GameObject)weapon;

            weaponList.Add(weap);
        }
    }
	

}
