using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicle
{
    [SerializeField]
    private List<WheelCollider> wheelColliders;

    void Update()
    {
        
    }
    public override void Move()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.position(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.rotation(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);
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
