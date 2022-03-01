using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleCode : MonoBehaviour
{
    public Rigidbody body;
    public bool isfalling;
    public float speed;
    [SerializeField] GameObject notbroken;
    [SerializeField] GameObject broken;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = body.velocity.y;
        if (body.velocity.y < -0.5)
            isfalling = true;

        if (isfalling == true && body.velocity.y == 0)
        {
            notbroken.SetActive(false);
            broken.SetActive(true);
         
        }

    }
}
