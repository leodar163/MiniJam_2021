using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    [Header("Refs Text")]
    [SerializeField] private TextMeshProUGUI scoreAdding;
    [SerializeField] private TextMeshProUGUI totalScore;
    [Header("Refs blinker")]
    [SerializeField] private GameObject angryBlinker;
    [SerializeField] private GameObject goodBlinker;
    [SerializeField] private GameObject okBlinker;
    [SerializeField] private GameObject badBlinker;



    public int score = 0;
    [SerializeField] private float refreshRate = 0;
    [Header("Threshold")]
    [SerializeField] private float deltaBad = -30;
    [SerializeField] private float deltaOk = -15;
    [SerializeField] private float deltaGood = -5;
    [SerializeField] private float deltaAngry = 10;
    [Header("Rewards")]
    [SerializeField] private int rewardBad = 0;
    [SerializeField] private int rewardOk = 50;
    [SerializeField] private int rewardGood = 100;
    [SerializeField] private int rewardAngry = 10;


    // Start is called before the first frame update
    void Start()
    {
        TurnOffBLinkers();  
        StartCoroutine(Scoring());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Scoring()
    {
        while(true)
        {
            yield return new WaitForSeconds(refreshRate - 0.1f);

            scoreAdding.text = "";

            yield return new WaitForSeconds(0.1f);
            int reward = DetermineReward();

            score += reward;

            scoreAdding.text = reward >= 0 ? "+" + reward : "-" + reward;
            totalScore.text = "" + score;
        }
    }

    private int DetermineReward()
    {
        float delta = InfoRessources.Instance.elecProd - InfoRessources.Instance.elecExpect;

        TurnOffBLinkers();

        if (delta >= deltaAngry)
        {
            angryBlinker.SetActive(true);
            return rewardAngry;
        }
        else if (delta >= deltaGood)
        {
            goodBlinker.SetActive(true);
            return rewardGood;
        }
        else if (delta >= deltaOk)
        {
            okBlinker.SetActive(true);
            return rewardOk;
        }

        badBlinker.SetActive(true);
        return rewardBad;
    }

    private void TurnOffBLinkers()
    {
        angryBlinker.SetActive(false);
        goodBlinker.SetActive(false);
        okBlinker.SetActive(false);
        badBlinker.SetActive(false);
    }
}
