using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bottleCode : MonoBehaviour
{
    public Rigidbody body;
    public bool isfalling;
    public bool isbroken = false;
    public float speed;
    [SerializeField] GameObject notbroken;
    [SerializeField] GameObject broken;

    //this is the stuff for the sound detection

    public GameObject[] enemy;
    public float[] enemydistance;
    public UnityEngine.AI.NavMeshAgent agent;
    private bool didit;
    private bool isGrabbed;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();

        enemy = GameObject.FindGameObjectsWithTag("enemy");
        enemydistance = new float[enemy.Length];
        path = new NavMeshPath();

    }

    // Update is called once per frame
    void Update()
    {
        speed = body.velocity.y;
        if (body.velocity.y < -0.5)
            isfalling = true;

        if (isfalling == true && body.velocity.y == 0)
        {
            broken.SetActive(true);
            notbroken.SetActive(false);
            isbroken = true;
        }
        checkenemy();

        if (isGrabbed == true)
        {
          
            gameObject.transform.localPosition = new Vector3(player.GetComponentInChildren<SphereCollider>().transform.position.x, 2.2f, player.GetComponentInChildren<SphereCollider>().transform.position.z);
            //gameObject.transform.localPosition = player.transform.position;
            
        }
    }

    private void checkenemy()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            //enemydistance[i] = printline(enemy[i].transform);
            printline(enemy[i].transform, i);
        }
        for (int i = 0; i < enemydistance.Length; i++)
        {
            //print(enemydistance[i]);
            if (enemydistance[i] <= 15 && isbroken == true && didit == false)
            {
                enemy[i].SendMessage("soundHeard", gameObject.transform.position);
                didit = true;
            }
        }
    }

    private float printline(Transform target, int position)
    {
        float sum = 0;
        elapsed += Time.deltaTime;


        elapsed -= 1.0f;
        NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            sum += (Vector3.Distance(path.corners[i], path.corners[i + 1]));
        }
        //print(sum);
        enemydistance[position] = sum;
        //return path.corners.Length;
        return sum;
    }

    void grabbed(GameObject who)
    {
        player = who;
        isGrabbed = true;
    }

    void ungrabbed()
    {
        isGrabbed = false;
        body.AddRelativeForce(0,5,0, ForceMode.Impulse);
    }
}
