using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombDisplay1 : MonoBehaviour
{

    public Sprite[] BombSprites;

    public Image BombUI;

    void Update()
    {
        BombUI.sprite = BombSprites[BombClear.ammo];

    }
}
