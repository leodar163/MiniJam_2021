using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TruckManager : MonoBehaviour
{
    public bool truckCalled = false;
    public bool truckWaiting = false;
    private float waitDelay = 5f;

    public void orderUraniumTruck()
    {
        StartCoroutine(TruckTimer());
    }

    public void orderTrashTruck()
    {
        StartCoroutine(TruckTimer());
    }

    private IEnumerator TruckTimer()
    {
        yield return new WaitForSeconds(waitDelay);
        truckWaiting = true;
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
