using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;


    void Start()
    {
        offset = transform.position - player.transform.position;


    }

    void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + offset, 0.3f);

    }
}
