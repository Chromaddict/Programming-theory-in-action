using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rightWheelRb;
    [SerializeField] Rigidbody leftWheelRb;
    [SerializeField] float maxAngularV;
    [SerializeField] float accelSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        SetupRb();
    }

    private void SetupRb()
    {
        leftWheelRb.maxAngularVelocity = maxAngularV;
        rightWheelRb.maxAngularVelocity = maxAngularV;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        
        leftWheelRb.AddTorque(Vector3.left * horizInput * Time.deltaTime * accelSpeed, ForceMode.Impulse);
        rightWheelRb.AddTorque(Vector3.right * horizInput * Time.deltaTime * accelSpeed, ForceMode.Impulse);
        leftWheelRb.AddTorque(Vector3.left * vertInput * Time.deltaTime * accelSpeed, ForceMode.Impulse);
        
        rightWheelRb.AddTorque(Vector3.left * vertInput * Time.deltaTime * accelSpeed, ForceMode.Impulse);
        if (Mathf.Approximately(0, horizInput) && Mathf.Approximately(0, vertInput))
        {
            leftWheelRb.angularVelocity = Vector3.zero;
            rightWheelRb.angularVelocity = Vector3.zero;
        }
    }
}
