using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] private KeyCode pauseCafe;

    // Start is called before the first frame update
    void Start()
    {
        Chrono.Instance.chronoUpdate.AddListener(() =>
        {
            CheckControls();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void CheckControls()
    {
        if(Input.GetKey(pauseCafe))
        {

        }
    }
}
