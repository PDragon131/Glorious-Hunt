using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public GameObject tDCamara;
    public GameObject tPCamara;

    private GameObject boss;

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");   
    }

    void Update()
    {
        if (!boss.activeSelf)
        {
            tDCamara.SetActive(false);
            tPCamara.SetActive(true);
        }
    }
}
