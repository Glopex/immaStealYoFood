using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIpatrol : MonoBehaviour
{
    
    public Transform player;
    public float playerDistance;
    public float awareAI = 5f;
    public float AIMoveSpeed;
    public float damping = 6.0f;
    public Transform[] navPoint;
    public UnityEngine.AI.NavMeshAgent agent;
    public int destPoint = 0;
    public Transform goal;
    public bool PlayerSpotted;
    [SerializeField] public GameObject state;

    //float radius = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
        agent.autoBraking = false;

    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);


        if (playerDistance < awareAI)
        {
            LookAtPlayer();
            
            //Debug.Log("Seen");
        }

        if (playerDistance < awareAI)
        {
            if (playerDistance > 5f) {
                //PlayerSpotted = true;
                
                Chase(); 
            }


        else

            GoToNextPoint();

        }
        
        {
            if (agent.remainingDistance < 0.5f)
                GoToNextPoint();
        }

        
    }



    void LookAtPlayer()
    {
        transform.LookAt(player);
    }


    void GoToNextPoint()
    {
        if (navPoint.Length == 0)
            return;
        agent.destination = navPoint[destPoint].position;
        destPoint = (destPoint + 1) % navPoint.Length;

    }


    void Chase()
    {
        
        agent.SetDestination(player.transform.position);
        agent.speed = 3f;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            state.SendMessage("spotted");
            awareAI = 25f;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            state.SendMessage("notSpotted");
            awareAI = 2.5f;
        }

    }
}
