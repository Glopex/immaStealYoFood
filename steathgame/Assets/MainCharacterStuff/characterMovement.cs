using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
    GameObject Player;
    Vector3 PlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject;
        PlayerPosition = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Player.transform.position = PlayerPosition;
    }

    public void OnUp()
    {
        PlayerPosition.x += 1; 
        PlayerPosition.z += 1;
        /*var v = input;
        Debug.Log(v);
        Vector2 inputVec = input.Get<Vector2>();
        PlayerPosition = new Vector3(inputVec.x, 0, inputVec.y);*/
    }
    public void OnDown()
    {
        PlayerPosition.x -= 1;
        PlayerPosition.z -= 1;
        
    }
    public void OnLeft()
    {
        PlayerPosition.x -= 1;
        PlayerPosition.z += 1;

    }
    public void OnRight()
    {
        PlayerPosition.x += 1;
        PlayerPosition.z -= 1;

    }
}
