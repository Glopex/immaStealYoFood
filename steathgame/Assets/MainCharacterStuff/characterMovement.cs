using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class characterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] public GameObject positionNose;
    bool iscrouched;
    private Vector3 _input;

    private void Update()
    {
        if (Input.GetKeyDown("left ctrl"))
        {
            if(iscrouched == false)
            {
                _speed = 2.5f;
                
                iscrouched = true;
            }
            else
            {
                _speed = 5f;
                iscrouched = false;
            }
            
            
        }


        GatherInput();
        Look();
        noiseSize();
    }

    private void FixedUpdate()
    {
        
        Move();
    }
    
    private void noiseSize()
    {
        
        SphereCollider noise = gameObject.GetComponentInChildren<SphereCollider>();
        if (_input == Vector3.zero)
        {
            noise.radius = 0f;
        }
        else
        {
            if (_speed == 5f)
            {
                positionNose.transform.localPosition = new Vector3(positionNose.transform.localPosition.x, .25f, positionNose.transform.localPosition.z);
                noise.radius = 7.5f;
            }
            else
            {
                noise.radius = 2.5f;
                positionNose.transform.localPosition = new Vector3(positionNose.transform.localPosition.x, -.5f, positionNose.transform.localPosition.z);
            }
                      }
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
       
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
    }

    
}

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
