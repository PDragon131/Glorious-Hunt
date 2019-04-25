using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParts : MonoBehaviour
{
    public int partHP;

    void Start()
    {
        partHP = 3500;
    }

    void Update()
    {
        if(partHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            partHP -= other.GetComponent<Bullet>().damage;
        }
    }

}
