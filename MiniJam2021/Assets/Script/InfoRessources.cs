using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InfoRessources : MonoBehaviour
{
    static private InfoRessources cela;

    static public InfoRessources Instance
    {
        get
        {
            if (cela) cela = FindObjectOfType<InfoRessources>();
            return cela;
        }
    }

    public float dechet = 0;
    public float uranium = 0;
    public float temperature = 0;
    public float elecProd = 0;
    public float elecExpect = 0;
    public float flotte = 0;

    // Start is called before the first frame update
    void Start()
    {
        Chrono.Instance.chronoUpdate.AddListener(() => { 
            UpdateRessources(); 
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateRessources()
    {

    }
}
