using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Audios : MonoBehaviour
{
    static private Audios cela;

    static public Audios Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<Audios>();
            return cela;
        }
    }
    [Header("Refs AudioSources")]
    [SerializeField] private AudioSource aSAlarme1;
    [SerializeField] private AudioSource aSAlarme2;
    [SerializeField] private AudioSource aSAlarme3;
    [SerializeField] private AudioSource aSAmbiance;
    [SerializeField] private AudioSource aSMusique;
    [SerializeField] private AudioSource aSTruck;
    [SerializeField] private AudioSource aSUI;
    [SerializeField] private AudioSource aSWater;
    [Header("Clips")]
    [SerializeField] private AudioClip alarme1;
    [SerializeField] private AudioClip alarme2;
    [SerializeField] private AudioClip alarme3;
    [SerializeField] private AudioClip Klaxon;
    [SerializeField] private AudioClip pshit;
    [SerializeField] private AudioClip augmenteUI;
    [SerializeField] private AudioClip diminueUI;
    [SerializeField] private AudioClip erreurUI;
    [SerializeField] private AudioClip gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayErreur()
    {
        aSUI.clip = erreurUI;
        aSUI.Play();
    }
    public void PlayKlaxon()
    {
        aSTruck.clip = Klaxon;
        aSTruck.Play();
    }
    public void PlayAlarmeTruck()
    {
        aSAlarme1.clip = alarme1;
        aSAlarme1.Play();
    }
    public void PlayAlarmeTrash()
    {
        aSAlarme2.clip = alarme2;
        aSAlarme2.Play();
    }
    public void StopAlarmeTrash()
    {
        aSAlarme2.Stop();
    }

    public void PlayAlarmeTemperature()
    {
        aSAlarme3.clip = alarme3;
        aSAlarme3.Play();
    }
    public void StopAlarmeTemperature()
    {
        aSAlarme3.Stop();
    }

    public void PlayAumgente()
    {
        aSUI.clip = augmenteUI;
        aSUI.Play();
    }
    public void PlayDiminue()
    {
        aSUI.clip = diminueUI;
        aSUI.Play();
    }
    public void PlayGameOver()
    {
        aSAmbiance.loop = true;
        aSAmbiance.clip = gameOver;
        aSAmbiance.Play();
    }
    public void PlayPshit()
    {
        aSWater.clip = pshit;
        aSWater.Play();
    }

}
