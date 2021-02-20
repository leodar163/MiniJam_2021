using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfoRessources : MonoBehaviour
{
    static private InfoRessources cela;

    static public InfoRessources Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<InfoRessources>();
            return cela;
        }
    }

    [Header("Ressources")]
    [Tooltip("barils de déchets nucléaires")]
    [Range(0,6)]
    public float dechet = 0;
    [Space(5)]
    [Tooltip("barils de combustibles nucléaires")]
    [Range(0,6)]
    public float uranium = 0;
    [Space(5)]
    [Tooltip("température au sein du réacteur")]
    [Range(0,100)]
    public float temperature = 0;
    [Space(5)]
    [Tooltip("production en électricité")]
    [Range(0,100)]
    public float elecProd = 0;
    [Space(5)]
    [Tooltip("production opti en électricité à atteindre")]
    [Range(0,100)]
    public float elecExpect = 0;
    [Space(5)]
    [Tooltip("flotte pour refroidir le réacteur disponible")]
    [Range(0,100)]
    public float flotte = 0;

    [Header("Ratio")]
    public float flotteRatio = 0.5f;
    public float maxRessource = 100f;
    public float minRessource = 0f;
    public float maxBaril = 6f;
    public float uraniumRatio = 0.1f;
    public float temperatureRatio = 1f;

    [Header("Events")]
    public UnityEvent barilDepleted = new UnityEvent();
    public UnityEvent temperatureRise = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        Chrono.Instance.chronoUpdate.AddListener(() => { 
            UpdateRessources(); 
        });
        barilDepleted.AddListener(() =>
        {
            if (dechet < maxBaril) dechet += 1;
            else print("GAME OVER - trop de déchets");
        });
        temperatureRise.AddListener(() =>
        {
            if (temperature < maxRessource) temperature += temperatureRatio * elecProd;
            else print("GAME OVER - surchauffe");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float usedUranium = 0;

    private void UpdateRessources()
    {
        flotte = flotte + flotteRatio >= maxRessource ? maxRessource : flotte + flotteRatio;
        
        float uraniumToRemove = uranium - uraniumRatio * elecProd >= minRessource ? uraniumRatio * elecProd : uranium;

        uranium -= uraniumToRemove;
        usedUranium += uraniumToRemove;

        if (usedUranium - 1 >= 0 )
        {
            usedUranium -= 1;
            barilDepleted.Invoke();
        }
        temperatureRise.Invoke();
    }

    public void AddUranium(float amount)
    {
        if (amount > 0) uranium = uranium + amount > maxBaril ? maxBaril : uranium + amount;
    }

    public void RemoveTrash(float amount)
    {
        if (amount > 0) dechet = dechet - amount < minRessource ? minRessource : dechet - amount;
    }
}