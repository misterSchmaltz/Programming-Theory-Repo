using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Vehicle
{
    [SerializeField]
    private float pitchPower, rollPower, yawPower, enginePower;
    private float activeRoll, activePitch, activeYaw;
    private float yawInput;

    void FixedUpdate()
    {
        if (isPlayerControlling)
        {
            Move();
        }
    }

    public override void Move()
    {
        throttleInput = Input.GetAxis("Jump");
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        yawInput = Input.GetAxis("Yaw");

        transform.position += transform.forward * enginePower * Time.deltaTime * throttleInput;

        activePitch = verticalInput * pitchPower * Time.deltaTime;
        activeRoll = horizontalInput * rollPower * Time.deltaTime;
        activeYaw = yawInput * yawPower * Time.deltaTime;

        transform.Rotate(activePitch * pitchPower * Time.deltaTime, 
            activeYaw * yawPower * Time.deltaTime,
            activeRoll * rollPower * Time.deltaTime,
            Space.Self);
    }

    public override void ActionCommand()
    {
        if (Input.GetButtonDown("Reset Button"))
        {
            ResetVehicle();
        }
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
