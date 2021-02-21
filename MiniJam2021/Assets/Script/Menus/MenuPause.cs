using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : Menu
{
    static protected MenuPause cela;

    static public MenuPause Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<MenuPause>();
            return cela;
        }
    }

    public bool isPaused
    {
        get
        {
            return isActive;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetPause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPause()
    {
        isActive = !isActive;

        if (isActive)
        {
            Audios.Instance.PlayAumgente();
            Time.timeScale = 0;
            visu.SetActive(true);
        }
        else
        {
            Audios.Instance.PlayDiminue();
            Time.timeScale = 1;
            visu.SetActive(false);
        }
    }

    public void OpenLink(string linkURL)
    {
        Application.OpenURL(linkURL);
    }
}
