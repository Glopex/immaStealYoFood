using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabScript : MonoBehaviour
{

    public bool grabbed = false;
    public bool keypressed;
    public GameObject enemyInFront;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown("e") && enemyInFront != null && grabbed == false)
        {
            print("funziona");
            enemyInFront.SendMessage("grabbed");
            grabbed = true;
        }
       else 
            if(Input.GetKeyDown("e") && enemyInFront != null && grabbed == true)
        {
            enemyInFront.SendMessage("ungrabbed");
            grabbed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
            
        if (other.CompareTag("enemy"))
            {
            enemyInFront = other.gameObject;  
            }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("enemy"))
        enemyInFront = null;
    }
}
