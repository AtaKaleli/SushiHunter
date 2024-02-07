using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance; //make UI accessable from anywhere and anyplace

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI performanceText;

    private float timer = 0;
    private int scoreValue = 0;

    [SerializeField] private GameObject gameOverPanel;


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

    public void UpdateAmmoInfo(int currrentBullet, int maxBullet)
    {
        ammoText.text = currrentBullet + "/" + maxBullet;
    }

    public void ShowStatistics(int reloadTime, int bulletsConsumed)
    {
        float accuracy = bulletsConsumed > 0 ? (float)scoreValue / bulletsConsumed * 100 : 0f;

        performanceText.text = "Sushies Hunted: " + scoreValue + "\n"
            + "Play Time: " + timer.ToString("#,#") + "\n"
            + "Bullets Consumed: " + bulletsConsumed.ToString("#,#") + "\n"
            + "Number of Reloads: " + reloadTime.ToString("#,#") + "\n\n"
            + "Your Accuracy: " + accuracy.ToString("#,#") + "%";
    }




    public void OpenGameOverScreen()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        ShowStatistics(0, 0);

    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}
