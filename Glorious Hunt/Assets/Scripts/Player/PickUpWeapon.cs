using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour {

    public Transform primarySlot;
    public Transform secondarySlot;

    private float pickCD;
    private float max;

    private void Start()
    {
        pickCD = 1f;
        max = pickCD;
    }

    private void Update()
    {
        pickCD += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Primary") && pickCD >= max)
        {
            primarySlot.DetachChildren();
            other.transform.parent = primarySlot;
            other.transform.localPosition = new Vector3(0,0.6f,0.3f);
            other.transform.rotation = transform.rotation;
            pickCD = 0;
        }
        else if (other.CompareTag("Secondary") && pickCD >= max)
        {
            secondarySlot.DetachChildren();
            other.transform.parent = secondarySlot;
            other.transform.localPosition = new Vector3(0, 0.6f, 0.3f);
            other.transform.rotation = transform.rotation;
            pickCD = 0;
        }
    }
}
