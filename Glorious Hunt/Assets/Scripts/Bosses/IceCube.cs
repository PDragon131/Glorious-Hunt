using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : MonoBehaviour
{
    public float despawn;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Wall") || other.CompareTag("Player"))
        {
            
            {
                Destroy(gameObject);
            }
            

        }
        
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
