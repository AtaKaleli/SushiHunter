using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject credits;

    void OnClickStartGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    void OnClickHowToPlay()
    {
        menu.SetActive(false);
        howToPlay.SetActive(true);
    }

    void OnClickCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    void OnClickExit()
    {
        Application.Quit();
    }

    void OnClickBackFromCredits()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

    void OnClickBackFromHTP()
    {
        menu.SetActive(true);
        howToPlay.SetActive(false);
    }

}
