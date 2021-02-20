using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTruck : Truck
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
        InfoRessources.Instance.RemoveTrash(barrelsToLoad);
        base.LoadStuff();
    }

    public override void Leave()
    {
        base.Leave();
    }
}
