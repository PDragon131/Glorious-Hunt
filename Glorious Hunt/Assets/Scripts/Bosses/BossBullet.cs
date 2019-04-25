using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour {

    public float despawn;
    public bool stabo;

    private void Start()
    {
        if(stabo == true)
        Destroy(gameObject, despawn);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Player"))
        {

            Destroy(gameObject);

        }

        if ((other.CompareTag("Wall") || other.CompareTag("Player")) && stabo == true)
        {
            Destroy(gameObject, despawn);
        }
    }
}
