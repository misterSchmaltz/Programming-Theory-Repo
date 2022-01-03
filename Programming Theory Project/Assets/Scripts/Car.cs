using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicle
{
    [SerializeField]
    private float horsePower = 0;
    [SerializeField]
    private float maxSteerAngle = 30;
    [SerializeField]
    private float motorForce = 50;
    private float steeringAngle;

    [SerializeField]
    private List<WheelCollider> wheelColliders;
    [SerializeField]
    private int wheelsOnGround;
    
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
        vehicleRb.centerOfMass = centerOfMass.transform.position;
    }
    void FixedUpdate()
    {
        if (isPlayerControlling)
        {
            
            Move();
            /*
            if (IsOnGround())
            {
                Move();
            }*/
        }
    }
    public override void Move()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        Accelerate();
        Steer();
        //transform.position(Vector3.forward * speed * Time.deltaTime * verticalInput);
        //vehicleRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        //transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;

        foreach(WheelCollider wheel in wheelColliders)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public override void ActionCommand()
    {

    }

    public override void EnterVehicle()
    {
        base.EnterVehicle();
    }

    public override void ExitVehicle()
    {
        base.ExitVehicle();
    }

    private void Steer()
    {
        steeringAngle = maxSteerAngle * horizontalInput;
        wheelColliders[0].steerAngle = steeringAngle;
        wheelColliders[1].steerAngle = steeringAngle;
    }

    private void Accelerate()
    {
        wheelColliders[0].motorTorque = verticalInput * motorForce;
        wheelColliders[1].motorTorque = verticalInput * motorForce;
    }
}
