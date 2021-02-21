using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Alarme : MonoBehaviour
{
    [SerializeField] private GameObject blinker;
    private bool isTurnedOn = false;
    System.Func<bool> turnOnOn = new System.Func<bool>(() => { return false; });
    public enum AlarmeType {dechet, truck, temperature, nulle};

    [SerializeField] private AlarmeType alarmeType = AlarmeType.nulle;

    // Start is called before the first frame update
    void Start()
    {
        if (alarmeType == AlarmeType.dechet)
        {
            turnOnOn = () => { if (InfoRessources.Instance.dechet >= InfoRessources.Instance.maxBaril - 1) return true; else return false; };
        }
        else if (alarmeType == AlarmeType.temperature)
        {
            turnOnOn = () => { if (InfoRessources.Instance.temperature >= InfoRessources.Instance.maxRessource - 15) return true; else return false; };
        }
        else
        {
            turnOnOn = () => { if (TruckManager.Instance.truckstate == TruckManager.TruckState.called) return true; else return false; };
        }

        Chrono.Instance.chronoUpdate.AddListener(() =>
        {
            TurnOnAllarme(turnOnOn);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnOnAllarme(System.Func<bool> predicate)
    {
        if(isTurnedOn != predicate.Invoke())
        {
            isTurnedOn = predicate.Invoke();

            if(isTurnedOn)
            {
                if (alarmeType == AlarmeType.dechet) Audios.Instance.PlayAlarmeTrash();
                else if (alarmeType == AlarmeType.temperature) Audios.Instance.PlayAlarmeTemperature();

                StartCoroutine(BlinkAlarme());
            }
            else
            {
                if (alarmeType == AlarmeType.dechet) Audios.Instance.StopAlarmeTrash();
                else if (alarmeType == AlarmeType.temperature) Audios.Instance.StopAlarmeTemperature();
            }
        }
    }

    private IEnumerator BlinkAlarme()
    {
        while(isTurnedOn)
        {
            blinker.SetActive(true);
            yield return new WaitForSeconds(1);
            blinker.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
