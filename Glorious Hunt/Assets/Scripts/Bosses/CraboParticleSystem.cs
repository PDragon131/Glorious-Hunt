using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraboParticleSystem : MonoBehaviour
{

    public GameObject leftClawParticles;
    public GameObject rightClawParticles;


    public void LeftClaw()
    {
        StartCoroutine(TimeLeft());
    }

    public void RightClaw()
    {
        StartCoroutine(TimeRight());
    }

    IEnumerator TimeLeft()
    {
        leftClawParticles.SetActive(true);

        yield return new WaitForSeconds(0.6f);

        leftClawParticles.SetActive(false);
    }

    IEnumerator TimeRight()
    {
        rightClawParticles.SetActive(true);

        yield return new WaitForSeconds(0.6f);

        rightClawParticles.SetActive(false);
    }


}
