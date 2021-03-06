﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Truck : MonoBehaviour
{
    [SerializeField] protected TruckManager truckManager;
    [SerializeField] protected int barrelsToLoad = 1;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }
    public override string ToString()
    {
        return name;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void CallAtGate()
    {
        Audios.Instance.PlayKlaxon();
        print(name + " est Arrivé");
    }

    public virtual void LoadStuff()
    {
        truckManager.truckstate = TruckManager.TruckState.atParking;
        print(name + " pose sa pèche dans le parking :");
        Leave();
    }

    public virtual void Leave()
    {
        truckManager.truckstate = TruckManager.TruckState.notHere;
        print(name + " se casse le camion");
    }
}
