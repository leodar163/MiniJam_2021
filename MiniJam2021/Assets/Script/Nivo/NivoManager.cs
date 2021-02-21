using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivoManager : MonoBehaviour
{
    [SerializeField] private Nivo nivoToPlay;
    [SerializeField] private int currentNivoIndex = 0;
    [SerializeField] private int currentEventOfNivoIndex = 0;
    private Nivo.EventNivo nextEventNivo;
    private int nextEventTiming;

    private bool isNextEventDefined = false;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Calendar.Instance.Init(nivoToPlay.dayAmount);
        InfoRessources.Instance.InitialiseRessources(nivoToPlay);

        Calendar.Instance.eventFinNivo.AddListener(() =>
        {
            EndNivo();
        });

        Chrono.Instance.chronoUpdate.AddListener(() =>
        {
            CheckEventNivo();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckEventNivo()
    {
        if(nivoToPlay.dayAmount == Calendar.Instance.minute / 60 / 24)
        {
            MenuEnd.Instance.EndGame();
            return;
        }

        if(!isNextEventDefined)
        {
            if (currentEventOfNivoIndex + 1 < nivoToPlay.eventsOfNivo.Count)
            {
                nextEventNivo = nivoToPlay.eventsOfNivo[currentEventOfNivoIndex + 1];
                nextEventTiming = nextEventNivo.dayOfEvent * 24 * 60 + nextEventNivo.hourOfEvent * 60 + nextEventNivo.minuteOfEvent;
            }
            else return;
        }

        if(Calendar.Instance.minute >= nextEventTiming)
        {
            InfoRessources.Instance.ApplieEventNivo(nextEventNivo);
            isNextEventDefined = false;

            if (currentEventOfNivoIndex + 1 < nivoToPlay.eventsOfNivo.Count) currentEventOfNivoIndex++;
        }
    }

    private void EndNivo()
    {

    }
}
