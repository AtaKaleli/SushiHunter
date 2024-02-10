using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject credits;

    public void OnClickStartGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void OnClickHowToPlay()
    {
        menu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void OnClickCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickBackFromCredits()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

    public void OnClickBackFromHTP()
    {
        menu.SetActive(true);
        howToPlay.SetActive(false);
    }

}
