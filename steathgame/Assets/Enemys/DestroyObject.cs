using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject turret;
    // Start is called before the first frame update
    private void Start()
    {
        turret.GetComponent<Turret>().turnoff = false;

    }
    void OnTriggerEnter(Collider collider)
    {
        //destroy enemy when shell collides with them and spawns dead model
       
        if (collider.gameObject.CompareTag("EnemyShell"))
        {
            turret.GetComponent<Turret>().turnoff = true;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
