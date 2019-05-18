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

    private Animator anim;

    public Transform firePoint;
    public GameObject bulletPref;
    public GameObject player;
    public GameObject particle;
    public int speed;

    void Start ()
    {
        max = 3f;
        fireRate = 0.2f;
        canFire = false;

        anim = GetComponentInChildren<Animator>();

    }
	
	void Update ()
    {
        attackCD += Time.deltaTime;
        fireCD += Time.deltaTime;

        if (attackCD >= max)
        {
            anim.SetBool("Dashing", true);
            particle.SetActive(true);
            canFire = true;
            transform.position += transform.forward * Time.deltaTime * speed;

        }
        else
        {
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
            anim.SetBool("Dashing", false);
            particle.SetActive(false);

        }
    }
}
