using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="nNvNivo", menuName = "Nivo")]
public class Nivo : ScriptableObject
{
    public int dayAmount;
    [Header("Ressources")]
    [Tooltip("barils de déchets nucléaires")]
    [Range(0, 6)]
    public float initialDechet = 0;
    [Space(5)]
    [Tooltip("barils de combustibles nucléaires")]
    [Range(0, 6)]
    public float initialUranium = 0;
    [Space(5)]
    [Tooltip("température au sein du réacteur")]
    [Range(0, 100)]
    public float initiaTemperature = 0;
    [Space(5)]
    [Tooltip("production en électricité")]
    [Range(0, 100)]
    public float initialElecProd = 0;
    [Space(5)]
    [Tooltip("production opti en électricité à atteindre")]
    [Range(0, 100)]
    public float initialElecExpect = 0;
    [Space(5)]
    [Tooltip("flotte pour refroidir le réacteur disponible")]
    [Range(0, 100)]
    public float initialFlotte = 0;

    [System.Serializable]
    public struct EventNivo
    {
        public int dayOfEvent;
        public int hourOfEvent;
        public int minuteOfEvent;
        public int elecExpectOfEvent;
    }

    public List<EventNivo> eventsOfNivo = new List<EventNivo>();
}
