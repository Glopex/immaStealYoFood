using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShell : MonoBehaviour
{
   
    // Start is called before the first frame update
    
    void OnTriggerEnter(Collider collider)
    {
        //destroys shell when it hits object to reduce clitter
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy (this.gameObject);
        }
         if (collider.gameObject.CompareTag("Map"))
        {
            
            Destroy (this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
