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
    [SerializeField] private KeyCode getFreshWater2;
    [SerializeField] private KeyCode increasePower;
    [SerializeField] private KeyCode decreasePower;

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
        if(Input.GetKeyUp(pauseCafe))
        {
            print("ouichef, isPaused = " + isPaused);
            if (isPaused) 
            {
                Audios.Instance.PlayAumgente();
                Time.timeScale = 1; isPaused = false;
            }
            else 
            {
                Audios.Instance.PlayDiminue();
                Time.timeScale = 0; isPaused = true;
            }
        }

        if (Input.GetKeyUp(appelerCamionUranium))
        {
            if (truckManager.truckstate == TruckManager.TruckState.waiting)
            {
                Audios.Instance.PlayAumgente();
                truckManager.SendTruckToParking();
            }
            else if (truckManager.truckstate == TruckManager.TruckState.notHere)
            {
                Audios.Instance.PlayAumgente();
                print("appeler un camion");
                truckManager.orderUraniumTruck();
            }
            else if (truckManager.truckstate == TruckManager.TruckState.called || truckManager.truckstate == TruckManager.TruckState.atParking)
            {
                Audios.Instance.PlayErreur();
            }
        }

        if (Input.GetKeyUp(appelerCamionPoubelle))
        {
            if (truckManager.truckstate == TruckManager.TruckState.waiting)
            {
                Audios.Instance.PlayAumgente();
                truckManager.SendTruckToParking();
            }
            else if (truckManager.truckstate == TruckManager.TruckState.notHere)
            {
                Audios.Instance.PlayAumgente();
                print("appeler un camion");
                truckManager.orderTrashTruck();
            }
            else if (truckManager.truckstate == TruckManager.TruckState.called || truckManager.truckstate == TruckManager.TruckState.atParking)
            {
                Audios.Instance.PlayErreur();
            }
        }

        if (Input.GetKeyUp(getFreshWater) || Input.GetKeyUp(getFreshWater2))
        {
            if(InfoRessources.Instance.flotte > 0) Audios.Instance.PlayPshit();
            else Audios.Instance.PlayErreur();

            InfoRessources.Instance.RefroidirLiquidement();
        }

        if (Input.GetKeyUp(increasePower))
        {
            if(InfoRessources.Instance.elecProd < 100) Audios.Instance.PlayAumgente();
            else Audios.Instance.PlayErreur();

            InfoRessources.Instance.MonterPuissance();
        }

        if (Input.GetKeyUp(decreasePower))
        {
            if (InfoRessources.Instance.elecProd > 0) Audios.Instance.PlayDiminue();
            else Audios.Instance.PlayErreur();

            InfoRessources.Instance.BaisserPuissance();
        }
    }
}