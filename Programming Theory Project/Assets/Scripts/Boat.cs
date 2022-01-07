using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Vehicle
{
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
        vehicleRb.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {
        if (isPlayerControlling)
        {
            if (Input.GetButtonDown("Reset Button"))
            {
                ResetVehicle();
            }

            Move();
            ActionCommand();
        }
    }

    public override void Move()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        vehicleRb.AddRelativeForce(Vector3.forward * speed * verticalInput);
        transform.Rotate(0.0f, horizontalInput * rotationSpeed, 0f);

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
}
