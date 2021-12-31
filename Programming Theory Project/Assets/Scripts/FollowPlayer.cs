using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private Vector3 offset = new Vector3(0, 8, -8.5f);
    //public GameObject targetObject { get; private set; }

    public static FollowPlayer Instance { get; private set; }

    void LateUpdate()
    {
        if (MainManager.Instance.currentVehicle != null)
            UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        transform.position = MainManager.Instance.currentVehicle.transform.position + offset;
        transform.rotation = MainManager.Instance.currentVehicle.transform.rotation;
    }
}
