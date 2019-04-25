using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
