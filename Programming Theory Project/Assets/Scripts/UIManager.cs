using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> vehicleControls;

    public void EnableControls(int index)
    {
        int currentEnabledControl = 0;
        bool activeControlUI = false;
        for (int i = 0; i < vehicleControls.Count; i++)
        {
            if (vehicleControls[i].active)
            {
                activeControlUI = true;
                currentEnabledControl = i;
            }
        }

        if (activeControlUI)
        {
            DisableControls(currentEnabledControl);
        }

        vehicleControls[index].SetActive(true);
    }

    public void DisableControls(int index)
    {
        if (vehicleControls[index].active)
        {
            return;
        }
        else
        {
            vehicleControls[index].SetActive(false);
        }
    }
}
