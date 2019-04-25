using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionCube : MonoBehaviour
{
    private GameObject player;

    private Vector3 offset;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + offset, 0.6f);
        
    }

}
