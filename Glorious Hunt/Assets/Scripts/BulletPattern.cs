using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern : MonoBehaviour {
    //WIP
    public float dirSwap;
    public int turnValue;

    private float max;
    private int dir;

    void Start()
    {
        max = dirSwap;
        dir = 1;
    }

    void Update ()
    {
        dirSwap += Time.deltaTime;

        transform.localPosition += new Vector3(turnValue * dir,0, turnValue * dir) * Time.deltaTime;

        if(dirSwap >= max)
        {
            dir *= -1;
            dirSwap = 0;
        }
	}
}
