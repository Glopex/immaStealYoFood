using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShell : MonoBehaviour
{

    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision)
    {
        //destroys shell when it hits object to reduce clitter
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy (this.gameObject);
        }
         if (collision.gameObject.CompareTag("Map"))
        {
            
            Destroy (this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
