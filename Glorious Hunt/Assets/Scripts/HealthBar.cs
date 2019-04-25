using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider hpBar;

    void Start()
    {
        hpBar = gameObject.GetComponent<Slider>();

        hpBar.maxValue = 10000;
    }


    void Update()
    {
        hpBar.value = BossBehaviour.bossHp;

    }
}
