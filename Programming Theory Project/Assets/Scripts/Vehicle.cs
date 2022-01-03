using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float rotationSpeed;
    [SerializeField]
    protected GameObject centerOfMass;
    protected Rigidbody vehicleRb;
    protected float horizontalInput;
    protected float verticalInput;
    protected float throttleInput;
    protected float actionButton;
    protected bool isPlayerControlling;


    // Start is called before the first frame update
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
        //vehicleRb.centerOfMass = centerOfMass.transform.position;
        isPlayerControlling = false;
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
