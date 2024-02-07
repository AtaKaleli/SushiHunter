using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance; //make UI accessable from anywhere and anyplace

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI timerText;

    private float timer = 0;
    private int scoreValue = 0;

    void Start()
    {
        instance = this; // meaningful if we have only  1 UI as an instance

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        ShowTimer();

       


    }




    private void ShowTimer()
    {
        if (timer >= 1)
            timerText.text = timer.ToString("#,#");
    }

    public void AddScore()
    {
        scoreValue++;
        scoreText.text = scoreValue.ToString();
    }
}
