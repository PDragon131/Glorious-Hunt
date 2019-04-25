using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShooter : MonoBehaviour {

    private float timer;
    private float max;
    [SerializeField] private GameObject trapBullet;
    [SerializeField] private Transform firePoint;

    void Start ()
    {
        timer = 1.5f;
        max = timer;
        timer = 0;
	}

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= max)
        {
            Instantiate(trapBullet, firePoint.position, transform.rotation, null);
            timer = 0;
        }
    }
        
}
