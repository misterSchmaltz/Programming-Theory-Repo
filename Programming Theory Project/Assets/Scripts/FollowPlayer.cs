using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private Vector3 offset = new Vector3(0, 8, -8.5f);
    [SerializeField]
    private float lookSpeed = 75;
    [SerializeField]
    private float followSpeed = 10;
    //public GameObject targetObject { get; private set; }
    private Transform objectFocus;

    public static FollowPlayer Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
        if (MainManager.Instance.currentVehicle != null && objectFocus != null)
        {
            UpdateLook();
            UpdateCameraPosition();
        }
    }

    void UpdateCameraPosition()
    {
        //transform.position = objectFocus.position + offset;
        //transform.rotation = MainManager.Instance.currentVehicle.transform.rotation;
        Vector3 targetPos = objectFocus.position + objectFocus.forward * offset.z + objectFocus.right * offset.x + objectFocus.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

    }

    void UpdateLook()
    {
        Vector3 lookDirection = objectFocus.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed * Time.deltaTime);
    }

    public void SetFocusObject(Transform newFocus)
    {
        objectFocus = newFocus;
    }

    public void SetCameraOffset(Vector3 offsetValues)
    {
        offset = offsetValues;
    }
}
