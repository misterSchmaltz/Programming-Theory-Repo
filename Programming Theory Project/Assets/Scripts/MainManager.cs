using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    [SerializeField]
    private List<GameObject> vehicleOptions;
    public GameObject currentVehicle { get; private set; }
    private UIManager uiManager;
    bool isGameActive = false;
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

    void Start()
    {
        SwitchVehicle(0);
    }

    public void SwitchVehicle(int chosenOption)
    {
        if (vehicleOptions[chosenOption] != currentVehicle)
        {
            vehicleOptions[chosenOption].gameObject.GetComponent<Vehicle>().EnterVehicle();
            if (currentVehicle != null)
            {
                currentVehicle.gameObject.GetComponent<Vehicle>().ExitVehicle();
            }
            currentVehicle = vehicleOptions[chosenOption];
            FollowPlayer.Instance.SetFocusObject(currentVehicle.transform);
        }
    }
}
