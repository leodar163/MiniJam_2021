using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TruckManager : MonoBehaviour
{
    static private TruckManager cela;

    static public TruckManager Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<TruckManager>();
            return cela;
        }
    }

    [SerializeField] private UraniumTruck uranTruck;
    [SerializeField] private TrashTruck trashTruck;
    [SerializeField] private Animator gateAnimator;
    [SerializeField] private Animator trashTruckAnimator;
    [SerializeField] private Animator uraniumTruckAnimator;

    private Truck currentTruck;

    public enum TruckState {notHere, called, waiting, atParking};

    public TruckState truckstate = TruckState.notHere;

    [SerializeField] private float waitDelay = 5f;
    [SerializeField] private float delayGate1 = 2f;
    [SerializeField] private float delayGate2 = 3f;

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
        yield return new WaitForSeconds(delayGate1);

        if(currentTruck is UraniumTruck) uraniumTruckAnimator.SetInteger("state", 1);
        else trashTruckAnimator.SetInteger("state", 1);

        yield return new WaitForSeconds(delayGate2);

        //isTruckWaiting = true;
        truckstate = TruckState.waiting;
        truckToCall.CallAtGate();
        if (currentTruck is UraniumTruck) uraniumTruckAnimator.SetInteger("state", 2);
        else trashTruckAnimator.SetInteger("state", 2);
    }
       

    public void SendTruckToParking()
    {
        gateAnimator.SetBool("Opening", true);
        if (currentTruck is UraniumTruck) uraniumTruckAnimator.SetInteger("state", 3);
        else trashTruckAnimator.SetInteger("state", 3);
        StartCoroutine(GateDelay());
    }

    private IEnumerator GateDelay()
    {
        yield return new WaitForSeconds(delayGate2);
        gateAnimator.SetBool("Opening", false);
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
