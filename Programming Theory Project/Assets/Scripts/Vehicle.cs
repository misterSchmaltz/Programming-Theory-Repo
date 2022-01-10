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
    [SerializeField]
    protected Vector3 cameraOffset;
    [SerializeField]
    protected GameObject vehicleControlsUI;
    protected Rigidbody vehicleRb;
    protected float horizontalInput;
    protected float verticalInput;
    public float throttleInput;
    protected float actionButton;
    protected bool isPlayerControlling;
    protected Vector3 spawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
        //vehicleRb.centerOfMass = centerOfMass.transform.position;
        isPlayerControlling = false;
        spawnPosition = new Vector3(transform.position.x, 5f, transform.position.z);
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
        FollowPlayer.Instance.SetCameraOffset(cameraOffset);
        EnableControlsUI();
    }

    public virtual void ExitVehicle()
    {
        isPlayerControlling = false;
        DisableControlsUI();
    }

    public void ResetVehicle()
    {
        transform.position = spawnPosition;
        transform.rotation = Quaternion.identity;
    }

    public void EnableControlsUI()
    {
        vehicleControlsUI.SetActive(true);
    }

    public void DisableControlsUI()
    {
        vehicleControlsUI.SetActive(false);
    }
}
