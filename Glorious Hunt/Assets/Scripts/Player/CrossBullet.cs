using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBullet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("BossBullet") && !other.name.Contains("Stabo"))
        {
            gameObject.GetComponent<Bullet>().damage -= 5;
            Destroy(other.gameObject);
        }
    }

}
