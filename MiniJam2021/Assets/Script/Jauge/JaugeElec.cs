using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaugeElec : Jauge
{
    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void UpdateValues()
    {
        base.UpdateValues();
        amount = InfoRessources.Instance.elecProd;
        max = InfoRessources.Instance.maxRessource;
    }
}
