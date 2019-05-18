using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControler : MonoBehaviour
{
    private int selected;
    [SerializeField] private bool attack;

    public List<GameObject> BossParts = new List<GameObject>();
    public bool canPick;
    public float timer;
    public float maxTimer;

    public GameObject lClaw;
    public GameObject rClaw;

    public GameObject removedL;
    public GameObject removedR;

    private void Start()
    {
        canPick = true;
        maxTimer = 2f;
        timer = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;
 
        if (canPick && timer >= maxTimer)
        {
           selected = Random.Range(0, BossParts.Count);
           attack = true;
           canPick = false;
        }

        if (attack)
        {
            BossParts[selected].gameObject.SetActive(true);
            timer = 0;
            canPick = true;
            attack = false;
        }

        if (!lClaw.activeSelf)
        {
            BossParts.Remove(removedL);
            
        }

        if (!rClaw.activeSelf)
        {
            BossParts.Remove(removedR);
        }

        if(BossBehaviour.bossHp <= 7500)
        {

            canPick = false;

        }

    }
}
