using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombDisplay : MonoBehaviour
{
    public Text text;

    void Update()
    {
        text.text = "Bomb Power: " + BombClear.ammo;
    }

}
