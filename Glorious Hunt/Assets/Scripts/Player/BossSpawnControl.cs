using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnControl : MonoBehaviour {

    public GameObject crabo;
    public GameObject stabo;
    public GameObject pede;
    public GameObject owlv;
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            crabo.SetActive(true);
            stabo.SetActive(true);
            owlv.SetActive(false);
            pede.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            crabo.SetActive(false);
            stabo.SetActive(false);
            owlv.SetActive(true);
            pede.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            crabo.SetActive(false);
            stabo.SetActive(false);
            owlv.SetActive(false);
            pede.SetActive(true);
        }

    }
}
