using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoinAPort : MonoBehaviour {

    public GameObject portPoint;
    public float cooldown;

    private bool going;
    private float max;
    private bool placed;
    private GameObject point;

    void Start ()
    {
        max = cooldown;
        placed = false;
        going = false;
	}

	void Update ()
    {
        cooldown += Time.deltaTime;

        if (Input.GetKey(KeyCode.E) && cooldown >= max && !placed)
        {
            point = Instantiate(portPoint, transform.position, transform.parent.rotation, null);
            placed = true;
            cooldown = 0;
        }

        if(Input.GetKey(KeyCode.E) && cooldown >= max && placed)
        {
            going = true;

        }

        if (going)
        {
            Player.iFrames = 0;

            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (var r in renderers)
            {
                r.enabled = false;
            }

            transform.position = Vector3.MoveTowards(transform.position, point.transform.position, 1.5f);

            if (transform.position == point.transform.position)
            {
                foreach (var r in renderers)
                {
                    r.enabled = true;
                }

                cooldown = 0;
                placed = false;
                Player.iFrames = 0;
                going = false;
                Destroy(point);
            }

        }


	}
}
