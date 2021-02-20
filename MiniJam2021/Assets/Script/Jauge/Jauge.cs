using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Jauge : MonoBehaviour
{
    [SerializeField] private Slider slider;
    protected float max = 0;
    protected float amount = 0;


    // Start is called before the first frame update
    protected void Start()
    {
        Chrono.Instance.chronoUpdate.AddListener(() =>
        {
            UpdateValues();
            UpdateGauge(max, amount);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateGauge(float max, float amount)
    {
        slider.value = amount / max;
    }

    protected virtual void UpdateValues()
    {

    }
}
