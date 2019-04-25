using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    private GameObject target;
    private GameObject player;

    private void Start()
    {
        target = GameObject.Find("Stabo");

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);

        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.LookAt(targetPosition);
    }
}
