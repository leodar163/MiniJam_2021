using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaugeSatisfaction : Jauge
{
    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void UpdateValues()
    {
        base.UpdateValues();
        amount = InfoRessources.Instance.elecExpect;
        max = InfoRessources.Instance.maxRessource;
    }
}
