using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBehaviour : MonoBehaviour
{
    //Fase change
    public GameObject fase2;
    public GameObject fase2_garraRight;
    public GameObject fase2_garraLeft;

    //Fase Rest
    private float rest;
    private float restTimer;

    //Fase 3
    public GameObject fase3;
    public Animator anim;
    public Animator anim2;
    public GameObject weaponStabo;
    public GameObject stabo;
    public GameObject garraLeft;
    public GameObject garraRight;

    //HP
    public static int bossHp;

    private NavMeshAgent agent;

    //from point to point
    private int destPoint = 0;

    //Central 
    [SerializeField] private GameObject centralPoint;

    [SerializeField] private Transform[] points;
    
    //Target
    public static GameObject player;

    //Random value
    //private static float attack;

    //Weapon Spawn
    Vector3 weaponPos;

    void Start()
    {
        //setting navemesh
        agent = GetComponent<NavMeshAgent>();
        
        //calling the move function that makes the side to side movement
        GotoNextPoint();

        //finds player at the start
        player = GameObject.FindWithTag("Player");

        //Set HP
        bossHp = 10000;

        rest = 5f;
        restTimer = rest;
        rest = 0f;

        }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        //Attack timer
        //attackCD += Time.deltaTime;

        rest += Time.deltaTime;

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f && bossHp > 5000)
        {
            GotoNextPoint();
        }


        if (bossHp <= 0)
        {
            weaponPos.x = transform.localPosition.x;
            weaponPos.z = transform.localPosition.z;

            int select = Random.Range(0, WeaponList.weaponList.Count - 1);

            Instantiate(WeaponList.weaponList[Random.Range(0, select)], weaponPos, transform.rotation);
            WeaponList.weaponList.RemoveAt(select);
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            bossHp -= 1000;
        }

    }

    void FixedUpdate()
    {
        agent.transform.LookAt(player.transform);

        if (bossHp <= 2000)
        {
            fase3.gameObject.SetActive(true);
            agent.destination = player.transform.position;
            agent.speed = 6;
            agent.acceleration = 6;
            fase2.gameObject.SetActive(false);
            weaponStabo.SetActive(true);
            stabo.SetActive(false);

            anim.SetBool("Fase3", true);
            anim2.SetBool("Fase 3", true);

            fase2_garraLeft.SetActive(false);
            fase2_garraRight.SetActive(false);

            

        }
        else if (bossHp <= 5000 && bossHp > 2000)
        {
            agent.destination = centralPoint.transform.position;
            fase2.gameObject.SetActive(true);
            fase2_garraLeft.SetActive(true);
            fase2_garraRight.SetActive(true);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Bullet"))
        {
            bossHp -= other.GetComponent<Bullet>().damage;
        }
    }

}
