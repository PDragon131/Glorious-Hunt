using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {

    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.SetActive(true);
            boss.SetActive(true);
            Destroy(transform.parent.gameObject);
        }
    }

}
