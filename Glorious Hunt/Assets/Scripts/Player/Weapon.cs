using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //firepoint and bullets
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private Transform exBulletPrefab;

    //sets if the weapon is a primary or a secondary
    [SerializeField] private bool primary;

    //max cd between shots
    [SerializeField] private float exMaxCooldown;
    [SerializeField] private float maxCooldown;

    private float cooldown;
    private float exCooldown;

    //checks if the player doing the primary shooting
    private bool shooting;

    void Start()
    {
        cooldown = maxCooldown;
        shooting = false;

        if (!primary)
        {
            exMaxCooldown = 0;
        }

        exCooldown = exMaxCooldown;
    }

    void Update()
    {
        if(transform.parent == null)
        {
            transform.position = new Vector3(transform.position.x ,0, transform.position.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
            shooting = false;


        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= maxCooldown)
        {
            Bullet bullet = Instantiate(bulletPrefab, firePoint.position, transform.parent.rotation, null).GetComponent<Bullet>();
            shooting = true;
            cooldown = 0;
        }

        if (Input.GetKey(KeyCode.Mouse1) && exCooldown >= exMaxCooldown && primary && !shooting)
        {
            Bullet bullet = Instantiate(exBulletPrefab, firePoint.position, transform.parent.rotation, null).GetComponent<Bullet>();
            exCooldown = 0;
        }

        cooldown += Time.deltaTime;
        exCooldown += Time.deltaTime;
    }

    

}
