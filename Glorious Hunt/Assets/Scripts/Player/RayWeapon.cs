using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayWeapon : MonoBehaviour
{

    public GameObject bullet;


    void Update()
    {
        if (transform.parent == null)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
            bullet.SetActive(false);


        if (Input.GetKey(KeyCode.Mouse0) && transform.parent != null)
        {
            bullet.SetActive(true);
           
        }


    }
}
