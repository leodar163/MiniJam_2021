using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calendar : MonoBehaviour
{
    private int hour = 0;
    private int minute = 0;
    private int day = 0;

    [SerializeField] private TextMeshProUGUI txtDay;
    [SerializeField] private TextMeshProUGUI txtHour;
    [SerializeField] private TextMeshProUGUI txtMinute;


    private void Start()
    {
        StartCoroutine(TikTak());
    }

    private IEnumerator TikTak()
    {
        while(true)
        {
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
