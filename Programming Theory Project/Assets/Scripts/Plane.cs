using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Vehicle
{
    [SerializeField]
    private float pitchPower, rollPower, yawPower, enginePower;
    [SerializeField]
    private GameObject propellerObject;
    [SerializeField]
    private GameObject payload;
    private float activeRoll, activePitch, activeYaw;
    private float yawInput;

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
            -activeRoll * rollPower * Time.deltaTime,
            Space.Self);
        ThrottlePropeller();
    }

    public override void ActionCommand()
    {
        if (Input.GetButtonDown("Action Button"))
        {
            SpawnPayload();
        }
    }

    public void SpawnPayload()
    {
        Instantiate(payload, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), payload.transform.rotation, this.transform);
    }

    public override void EnterVehicle()
    {
        base.EnterVehicle();
        PropellerIdle();
    }

    public override void ExitVehicle()
    {
        base.ExitVehicle();
        TurnOffPropeller();
    }

    public void ThrottlePropeller()
    {
        propellerObject.transform.Rotate(Vector3.forward * (Time.deltaTime * 30 + ( 30 * throttleInput)));
    }

    public void PropellerIdle()
    {
        propellerObject.transform.Rotate(Vector3.forward * (30 * Time.deltaTime));
    }

    public void TurnOffPropeller()
    {
        propellerObject.transform.Rotate(new Vector3(0, 0, 0));
    }
}
