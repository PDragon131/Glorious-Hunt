using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int force;
    public int damage;

    public bool ray;

    public GameObject particles;

    private void Start()
    {
        if (!ray)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        }
        
    }

    void OnEnable()
    {
        if (ray)
        {
            particles.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!ray)
        {

            if (damage == 0)
            {
                Destroy(gameObject);
            }

            if (other.CompareTag("Boss"))
            {
                Instantiate(particles, transform.position, transform.rotation, null);
                Destroy(gameObject);
            }

            if (other.CompareTag("Wall"))
            {

                Destroy(gameObject);

            }
        }
        else
        {
            if (other.CompareTag("Boss"))
            {
                particles.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(ray && other.CompareTag("Boss"))
        {
            particles.SetActive(false);
        }
    }
}
