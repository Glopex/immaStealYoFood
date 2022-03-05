using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIpatrol1 : MonoBehaviour
{
    Animator animator;
    public Transform player;
    [SerializeField] public NavMeshPath path;
    public float playerDistance;
    public float awareAI = 5f;
    public float AIMoveSpeed;
    public float damping = 6.0f;
    public Transform[] patrolPoint; 
    public UnityEngine.AI.NavMeshAgent agent;
    public int destPoint = 0;
    public Transform goal;
    public bool Spotted;
    public bool isGrabbed;
    private bool heardsound;
    public int numberOfChilds;
    private int currentCheckPoint;
    private int NumberOfChilds;
    private int loopcheck = -1;
    private bool PlayerSpotted;
    [SerializeField] public GameObject state;

    //float radius = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        path = new NavMeshPath();
        Spotted = false;
        int loopcheck=-1;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        for(int i = 0; i < gameObject.transform.parent.childCount;  i++)
        {
            if (gameObject.transform.parent.GetChild(i).CompareTag("checkpoint"))
                NumberOfChilds++;
            print(numberOfChilds);
        }
        patrolPoint = new Transform [NumberOfChilds];
        for (int i = 0; i < gameObject.transform.parent.childCount; i++)
        {
            if (gameObject.transform.parent.GetChild(i).CompareTag("checkpoint"))
            {
                loopcheck++;
                print("diocane funzionava0");
                patrolPoint[loopcheck] = gameObject.transform.parent.GetChild(i).transform;
            }

        }
        currentCheckPoint = 0;
        print(numberOfChilds);
    }

    // Update is called once per frame
    void Update()
    {
        //THIS IS FOR PLAYER DIST
        playerDistance = Vector3.Distance(player.position, transform.position);

        CheckPointList();

        if (PlayerSpotted == true)
            Chase();
        else
            if(heardsound == true)
        {
            investigatesound();
        }
        else
            goToCP();
        if (isGrabbed == true && PlayerSpotted == false)
        {
            animator.SetBool("Grabbed", true);
            gameObject.transform.position = new Vector3(player.GetComponentInChildren<SphereCollider>().transform.position.x, 2, player.GetComponentInChildren<SphereCollider>().transform.position.z);

        }
        else 
        {
            animator.SetBool("Grabbed", false);
        }

        /*
        //HENLO THIS IS MY CODE. HI GAB
        if (playerDistance < awareAI)
        {
            LookAtPlayer();

            //Debug.Log("Seen");
        }

        if (playerDistance < awareAI)
        {
            if (playerDistance > 1f)
            {
                //PlayerSpotted = true;
                
                Chase();
               
            }


            else
           
            goToCP();
            

        }*/
        //HENLO THIS CODE ENDS HERE. MORE BELOW
    }


    public void CheckPointList()
    {
        if ((gameObject.transform.position.x >= patrolPoint[currentCheckPoint].position.x-0.2f && gameObject.transform.position.x <= patrolPoint[currentCheckPoint].position.x + 0.2f) && (gameObject.transform.position.z >= patrolPoint[currentCheckPoint].position.z - 0.2f && gameObject.transform.position.z <= patrolPoint[currentCheckPoint].position.z + 0.2f))
            if (currentCheckPoint < (patrolPoint.Length-1))
                currentCheckPoint++;
            else
                currentCheckPoint = 0;

       
    }
    public void goToCP()
    {
        animator.SetBool("Spotted", false);
        NavMesh.CalculatePath(gameObject.transform.position, patrolPoint[currentCheckPoint].position, NavMesh.AllAreas, path);
        agent.destination = patrolPoint[currentCheckPoint].position;

    }

    void grabbed()
    {
        isGrabbed = true;
    }
    void ungrabbed()
    {
        isGrabbed = false;
    }

    //THIS IS THE MORE CODE
    void Chase()
    {
        animator.SetBool("Spotted", true);
        agent.SetDestination(player.transform.position);
        agent.speed = 3f;
    }

    void LookAtPlayer()
    {
        transform.LookAt(player);
    }
    void spotted(bool spotted)
    {
        PlayerSpotted = spotted;
    }

    void soundHeard(Vector3 soundSource)
    {
        heardsound = true;
        NavMesh.CalculatePath(gameObject.transform.position, soundSource, NavMesh.AllAreas, path);
        agent.SetDestination(soundSource);
    }

    void investigatesound()
    {
        if((gameObject.transform.position.x >= agent.destination.x - 0.2f && gameObject.transform.position.x <= agent.destination.x + 0.2f) && (gameObject.transform.position.z >= agent.destination.z - 0.2f && gameObject.transform.position.z <= agent.destination.z + 0.2f))
        {
            StartCoroutine(ExampleCoroutine());
            
        }
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        heardsound = false;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
