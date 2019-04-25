using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpDisplay : MonoBehaviour {

    public Text text;

    void Update ()
    {
            text.text = "Player HP: " + Player.playerHP;
	}
}
