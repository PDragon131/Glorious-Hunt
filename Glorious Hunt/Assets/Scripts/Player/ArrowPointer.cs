using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public GameObject target;
    private GameObject player;
    private Renderer arrowRender;


    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        arrowRender = gameObject.GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        
            
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);

            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.LookAt(targetPosition);


        if (target.activeSelf)
        {
            arrowRender.enabled = true;
        }
        else
        {
            arrowRender.enabled = false;
        }
    }
}
