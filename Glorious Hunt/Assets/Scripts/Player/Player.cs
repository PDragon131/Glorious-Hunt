using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static int playerHP;

    private float cD;
    private float maxCD;

    public static float iFrames;
    private float maxIFrames;

    public GameObject hitParticle;
    public GameObject iFrameParticle;

    void Start ()
    {
        playerHP = 10;
        cD = 0.2f;
        maxCD = cD;

        iFrames = 2f;
        maxIFrames = iFrames;
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }

        cD += Time.deltaTime;
        iFrames += Time.deltaTime;

        if (playerHP <= 0)
        {
            SceneManager.LoadScene("Main Menu");
        }

        if (Input.GetKey(KeyCode.C))
        {
            playerHP += 60;
        }
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("BossBullet") || other.CompareTag("Boss")) && iFrames >= maxIFrames)
        {
            playerHP -= 1;
            iFrames = 0f;

            StartCoroutine(HitVFX());
            
        }
    }

    IEnumerator HitVFX()
    {
        hitParticle.SetActive(true);
        iFrameParticle.SetActive(true);
        yield return new WaitForSeconds(2f);
        hitParticle.SetActive(false);
        iFrameParticle.SetActive(false);
    }


}
