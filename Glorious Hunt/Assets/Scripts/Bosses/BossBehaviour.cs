using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBehaviour : MonoBehaviour
{
    //Fase 2
    public GameObject ray1;
    public GameObject ray2;
    public GameObject spread;
    public GameObject topCenterPoint;

    //Fase change 3
    public GameObject fase3;
    public GameObject fase3_garraRight;
    public GameObject fase3_garraLeft;

    //Fase 4
    public GameObject fase4;
    public Animator anim;
    public Animator anim2;
    public GameObject stabo;
    public GameObject garraLeft;
    public GameObject garraRight;
    public GameObject weaponStabo;

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

    //Particles
    private int particlefase;

    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;


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

        particlefase = 1;

        StartCoroutine(FaseParticle());

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

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f && bossHp > 5000)
        {
            GotoNextPoint();
        }


        if (bossHp <= 0)
        {
            /*
            weaponPos.x = transform.localPosition.x;
            weaponPos.z = transform.localPosition.z;

            int select = Random.Range(0, WeaponList.weaponList.Count - 1);

            Instantiate(WeaponList.weaponList[Random.Range(0, select)], weaponPos, transform.rotation);
            WeaponList.weaponList.RemoveAt(select);
            */
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            bossHp -= 500;
        }

        if(bossHp <= 7500 && particlefase == 1)
        {
            StartCoroutine(FaseParticle());
            StartCoroutine(Fase3());
            particlefase++;
        }

        else if(bossHp <= 5000 && particlefase == 2)
        {
            ray1.SetActive(true);
            ray2.SetActive(true);
            StartCoroutine(FaseParticle());
            StartCoroutine(Fase2());
            particlefase++;

        }
        else if (bossHp <= 2500 && particlefase == 3)
        {
            StartCoroutine(FaseParticle());
            stabo.SetActive(false);

            ray1.SetActive(false);
            ray2.SetActive(false);

            stabo.SetActive(false);
            spread.SetActive(false);
            anim.SetBool("Fase2", false);
            anim2.SetBool("Fase2", false);

            anim.SetBool("Fase4", true);
            weaponStabo.gameObject.SetActive(true);   

            particlefase++;
        }

    }

    void FixedUpdate()
    {

        if (bossHp > 7500)
        {
            agent.transform.LookAt(player.transform);
        }

        else if (bossHp <= 7500 && bossHp > 5000)
        {
            
            agent.destination = centralPoint.transform.position;
            agent.transform.LookAt(player.transform);
        }

        else if (bossHp <= 5000 && bossHp > 2500)
        {
            agent.destination = topCenterPoint.transform.position;
            agent.transform.LookAt(Vector3.zero);
        }

        else if (bossHp <= 2500)
        {
            agent.destination = topCenterPoint.transform.position;
            agent.transform.LookAt(Vector3.zero);
            fase4.gameObject.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Bullet"))
        {
            bossHp -= other.GetComponent<Bullet>().damage;
        }
    }


    IEnumerator FaseParticle()
    {
        particle1.SetActive(true);
        particle2.SetActive(true);
        particle3.SetActive(true);

        yield return new WaitForSeconds(2f);

        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
    }

    IEnumerator Fase2()
    {
        fase3.gameObject.SetActive(false);
        fase3_garraLeft.SetActive(false);
        fase3_garraRight.SetActive(false);

        anim.SetBool("Fase2", true);
        anim2.SetBool("Fase2", true);

        yield return new WaitForSeconds(10f);
        spread.SetActive(true);
    }

    IEnumerator Fase3()
    {
        /*
        anim.SetBool("Fase2", false);
        anim2.SetBool("Fase2", false);
        spread.SetActive(false);
        gameObject.GetComponent<AttackControler>().timer = 0;
        */
        yield return new WaitForSeconds(3f);

        stabo.SetActive(true);
        fase3.gameObject.SetActive(true);
        fase3_garraLeft.SetActive(true);
        fase3_garraRight.SetActive(true);
    }
}
