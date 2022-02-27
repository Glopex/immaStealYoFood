using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class checkEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public float[] enemydistance;
    public UnityEngine.AI.NavMeshAgent agent;
    
    private NavMeshPath path;
    private float elapsed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        enemydistance = new float[enemy.Length];
        path = new NavMeshPath();
        elapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<enemy.Length; i++)
        {
            //enemydistance[i] = printline(enemy[i].transform);
            printline(enemy[i].transform, i);
        }
        for(int i = 0; i<enemydistance.Length; i++)
        {
            //print(enemydistance[i]);
            if(enemydistance[i] <= 2)
            {
                print("diocane ti ha sgamato " + i);
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

  
}

