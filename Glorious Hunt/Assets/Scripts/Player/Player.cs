using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static int playerHP;

    [SerializeField] private GameObject cheatWeapon;
    private float cD;
    private float maxCD;

    public static float iFrames;
    private float maxIFrames;

    void Start ()
    {
        playerHP = 200;
        cD = 0.2f;
        maxCD = cD;

        iFrames = 1.5f;
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
            playerHP -= 20;
            iFrames = 0f;
            
        }
    }


}
