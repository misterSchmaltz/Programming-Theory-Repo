using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private GameObject centerOfMass;
    private Rigidbody vehicleRb;
    private float horizontalInput, verticalInput, throttleInput, actionButton;
    private bool isPlayerControlling;


    // Start is called before the first frame update
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
        vehicleRb.centerOfMass = centerOfMass.transform.position;
    }

    public virtual void Move()
    {

    }

    public virtual void ActionCommand()
    {

    }

    public virtual void EnterVehicle()
    {
        //FollowPlayer.Instance.SetTargetObject(this.gameObject);
        isPlayerControlling = true;
    }

    public virtual void ExitVehicle()
    {
        isPlayerControlling = false;
    }
}
