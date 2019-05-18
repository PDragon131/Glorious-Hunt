using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase4Bullet : MonoBehaviour
{
    private float fireRate;
    private float fireCD;

    public Transform firePoint;
    public GameObject bulletPref;

    void Start()
    {
        fireRate = 0.4f;
    }

    void Update()
    {
      fireCD += Time.deltaTime;

        if (fireCD >= fireRate)
        {
            Instantiate(bulletPref, firePoint.position, transform.rotation, null).GetComponent<Bullet>();
            fireCD = 0;
        }
    }
}
