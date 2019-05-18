using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeGun : MonoBehaviour
{

    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform bulletPrefab;

    //sets if the weapon is a primary or a secondary
    [SerializeField] private bool primary;

    [SerializeField] private float cooldown;

    //checks if the player doing the primary shooting
    public static bool shooting;

    public GameObject vFX;

    void Start()
    {
        shooting = false;
    }

    void Update()
    {
        if (transform.parent == null)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        if (Input.GetKey(KeyCode.Mouse0) && !shooting)
        {
            StartCoroutine(ChargeShoot());
        }

    }

    IEnumerator ChargeShoot()
    {
        shooting = true;
        vFX.SetActive(true);
        yield return new WaitForSeconds(cooldown);
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, transform.parent.rotation, null).GetComponent<Bullet>();
        vFX.SetActive(false);
        shooting = false;
    }

}
