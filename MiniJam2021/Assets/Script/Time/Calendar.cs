using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Calendar : MonoBehaviour
{

    private static Calendar cela;

    public static Calendar Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<Calendar>();
            return cela;
        }
    }

    public UnityEvent eventFinNivo = new UnityEvent();
    

    public int minute = 0;
    public int maxDay = 5;

    [SerializeField] private TextMeshProUGUI txtDay;
    [SerializeField] private TextMeshProUGUI txtMaxDay;
    [SerializeField] private TextMeshProUGUI txtHour;
    [SerializeField] private TextMeshProUGUI txtMinute;


    private void Start()
    {

    }

    public void Init(int maximuOfDay)
    {
        maxDay = maximuOfDay;
        txtMaxDay.text = "/" + maxDay;
        StartCoroutine(TikTak());
    }

    private IEnumerator TikTak()
    {
        while(true)
        {
            if(minute / 60 / 24 >= maxDay)
            {
                eventFinNivo.Invoke();
                break;
            }
            yield return new WaitForSeconds(1);
            minute += 30;

            MakeCalendar();
        }
    }

    private void MakeCalendar()
    {
        txtMinute.text = minute % 60 == 0 ? "00" : "" +  (minute % 60);
        txtHour.text = "" + (minute / 60 % 24);
        txtDay.text = "" + (minute / 60 / 24);
    }
}
