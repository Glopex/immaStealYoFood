using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{

    public GameObject EnemyModel;
    public AudioSource playSound;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        //destroy enemy when shell collides with them and spawns dead model
       
        if (collider.gameObject.CompareTag("EnemyShell"))
        {
           
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
