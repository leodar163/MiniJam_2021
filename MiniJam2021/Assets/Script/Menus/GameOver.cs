using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : Menu
{
    static protected GameOver cela;

    static public GameOver Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<GameOver>();
            return cela;
        }
    }

    [SerializeField] private TextMeshProUGUI message;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireGameOver()
    {
        if (!isActive)
        {
            isActive = true;
            Time.timeScale = 0;
            Audios.Instance.PlayGameOver();
            visu.SetActive(true);
        }
    }

    public void FireGameOver(string messageToDraw)
    {
        message.text = messageToDraw;
        FireGameOver();
    } 

    public void Restart()
    {
        print("Game restarted");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
