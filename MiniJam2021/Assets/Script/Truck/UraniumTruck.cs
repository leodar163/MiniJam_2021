using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UraniumTruck : Truck
{
    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();

    }

    
    public override void GoToParking()
    {
        base.GoToParking();
    }

    public override void LoadStuff()
    {
        InfoRessources.Instance.AddUranium(barrelsToLoad);
        base.LoadStuff();
    }

    public override void Leave()
    {
        base.Leave();
    }
}
