using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [Header("refs")]
    [SerializeField] private TruckManager truckManager;
    [Space(20)]
    [SerializeField] private KeyCode pauseCafe;
    [SerializeField] private KeyCode appelerCamionUranium;
    [SerializeField] private KeyCode appelerCamionPoubelle;
    [SerializeField] private KeyCode getFreshWater;
    
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        //Chrono.Instance.chronoUpdate.AddListener(() =>
        //{
        //    CheckControls();
        //});
    }

    // Update is called once per frame
    void Update()
    {
        CheckControls();
    }

    private void CheckControls()
    {
        if(Input.GetKey(pauseCafe))
        {
            if (isPaused) Time.timeScale = 1;
            else Time.timeScale = 0;
        }

        if (Input.GetKeyUp(appelerCamionUranium))
        {
            if (truckManager.truckstate == TruckManager.TruckState.waiting)
            {
                truckManager.SendTruckToParking();
            }
            else if (truckManager.truckstate == TruckManager.TruckState.notHere)
            {
                print("appeler un camion");
                truckManager.orderUraniumTruck();
            }
        }

        if (Input.GetKeyUp(appelerCamionPoubelle))
        {
            if (truckManager.truckstate == TruckManager.TruckState.waiting)
            {
                truckManager.SendTruckToParking();
            }
            else if (truckManager.truckstate == TruckManager.TruckState.notHere)
            {
                print("appeler un camion");
                truckManager.orderTrashTruck();
            }
        }

        if (Input.GetKey(getFreshWater))
        {

        }
    }
}
