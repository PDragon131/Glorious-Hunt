using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpDisplay : MonoBehaviour {

    //https://www.youtube.com/watch?v=5KwkfGfaRNU

    public Sprite[] HeartSprites;

    public Image HearthUI;

    void Update ()
    {
        HearthUI.sprite = HeartSprites[Player.playerHP];

	}
}
