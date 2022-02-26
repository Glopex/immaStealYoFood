using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changestate : MonoBehaviour
{
    [SerializeField] public GameObject questionmark;
    [SerializeField] public GameObject excmark;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spotted()
    {
        excmark.SetActive(true);
    }

    public void notSpotted()
    {
        excmark.SetActive(false);
    }
}
