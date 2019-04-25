using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMovement : MonoBehaviour {

    private Vector3 target;

    public bool trap;

	void Start ()
    {
       
        if (!trap)
        {
            target = BossBehaviour.player.transform.position;
        }
        else
        {
            target = GameObject.FindWithTag("Player").transform.position;
        }
    }

	void FixedUpdate ()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 20 * Time.deltaTime);

        if (transform.position == target)
        {
            Destroy(gameObject);
        }
    }
}