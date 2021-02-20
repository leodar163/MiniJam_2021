using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TruckManager : MonoBehaviour
{
    [SerializeField] private UraniumTruck uranTruck;
    [SerializeField] private TrashTruck trashTruck;

    private Truck currentTruck;

    public bool isTruckCalled = false;
    public bool isTruckWaiting = false;

    public enum TruckState {notHere, called, waiting, atParking};

    public TruckState truckstate = TruckState.notHere;

    [SerializeField] private float waitDelay = 5f;

    public void orderUraniumTruck()
    {
        StartCoroutine(TruckTimer(uranTruck));
    }

    public void orderTrashTruck()
    {
        StartCoroutine(TruckTimer(trashTruck));
    }

    private IEnumerator TruckTimer(Truck truckToCall)
    {
        currentTruck = truckToCall;
        truckstate = TruckState.called;
        yield return new WaitForSeconds(waitDelay);
        //isTruckWaiting = true;
        truckstate = TruckState.waiting;
        truckToCall.CallToGate();
    }
       

    public void SendTruckToParking()
    {
        if(currentTruck && truckstate == TruckState.waiting) currentTruck.GoToParking();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
