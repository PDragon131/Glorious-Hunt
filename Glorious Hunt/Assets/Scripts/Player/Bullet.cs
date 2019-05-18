using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int force;
    public int damage;

    public GameObject particles;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);

    }

    private void OnTriggerEnter(Collider other)
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

}
