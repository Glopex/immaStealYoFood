using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabScript : MonoBehaviour
{

    public bool grabbed = false;
    public bool keypressed;
    public GameObject enemyInFront;
    public GameObject bottle;
    public GameObject what;
    public GameObject nowgrabbing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown("e") && what != null && grabbed == false)
        {
            print("funziona");
            nowgrabbing = what;
            nowgrabbing.SendMessage("grabbed", gameObject);
            
            grabbed = true;
        }
       else 
            if(Input.GetKeyDown("e") && grabbed == true)
        {
            nowgrabbing.SendMessage("ungrabbed");
            nowgrabbing = null;
            grabbed = false;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
            
        if (other.CompareTag("enemy") || other.CompareTag("bottle"))
            {
            what = other.gameObject;  
            }

        
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("enemy"))
        what = null;

        if (other.CompareTag("bottle"))
            what = null;
    }
}
