using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuEnd : Menu
{
    static protected MenuEnd cela;

    static public MenuEnd Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<MenuEnd>();
            return cela;
        }
    }

    [SerializeField] private TextMeshProUGUI message;

    private void Update()
    {

    }

    public void Restart()
    {
        GameOver.Instance.Restart();       
    }

    public void EndGame()
    {
        if (!isActive)
        {
            isActive = true;
            Time.timeScale = 0;
            message.text = "CONGRATULATION\nYou've reached " + Score.Instance.score + " satisfaction points\nPlease feel free to play again";
            visu.SetActive(true);
        }
    }
}
