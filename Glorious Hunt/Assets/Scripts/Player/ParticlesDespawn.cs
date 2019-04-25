using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDespawn : MonoBehaviour
{
    private float time;
    private float rate;


    void Start()
    {
        time = 0;
        rate = 1.2f;
    }

    void Update()
    {
        time += Time.deltaTime;

        if(time >= rate)
        {
            Destroy(gameObject);

        }
    }
}
