using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class staboBehaviour : MonoBehaviour {

    private float attackCD;
    private float max;
    private float fireRate;
    private float fireCD;
    private bool canFire;

    public Transform firePoint;
    public GameObject bulletPref;
    public GameObject player;
    public int speed;

    void Start ()
    {
        max = 3f;
        fireRate = 0.1f;
        canFire = false;
    }
	
	void Update ()
    {
        attackCD += Time.deltaTime;
        fireCD += Time.deltaTime;

        if (attackCD >= max)
        {
            canFire = true;
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else
        {
            /*
            canFire = false;
            gameObject.transform.LookAt(player.transform.position);

            Vector3 rotation = gameObject.transform.localRotation.eulerAngles;
            rotation.x = 0;

            gameObject.transform.localRotation = Quaternion.Euler(rotation);
            */
            canFire = false;

            Quaternion lookOnLook = Quaternion.LookRotation(player.transform.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, Time.deltaTime * 2);

            Vector3 rotation = gameObject.transform.localRotation.eulerAngles;
            rotation.x = 0;

            gameObject.transform.localRotation = Quaternion.Euler(rotation);
        }

        if (canFire && fireCD >= fireRate)
        {
            Instantiate(bulletPref, firePoint.position, transform.rotation, null).GetComponent<Bullet>();
            fireCD = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Wall") && attackCD > max)
        {

            attackCD = 0;
            
        }
    }
}
