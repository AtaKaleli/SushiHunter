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
    [SerializeField] private GameObject Special_case0;
    [SerializeField] private GameObject Special_case1;
    [SerializeField] private GameObject Special_case2;
    [SerializeField] private GunController gunController;
    private bool special_case0_check;
    private bool special_case1_check;
    private bool special_case2_check;

    private float timer = 0;
    private int scoreValue = 0;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private PoweshotSpawner powershotSpawner;


    void Start()
    {
        instance = this; // meaningful if we have only  1 UI as an instance
        gunController = FindObjectOfType<GunController>();

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

    public void ShowStatistics(int bulletsConsumed)
    {
        float accuracy = bulletsConsumed > 0 ? (float)scoreValue / bulletsConsumed * 100 : 0f;


        performanceText.text = "Sushies Hunted: " + scoreValue + "\n"
            + "Bullets Consumed: " + bulletsConsumed.ToString("#,#") + "\n"
            + "Powershot Used: " + powershotSpawner.powershotUsed.ToString() + "\n"
            + "Play Time: " + timer.ToString("#,#") + " seconds" + "\n\n"
            + "Your Accuracy: " + accuracy.ToString("#,#") + "%";
    }




    public void OpenGameOverScreen()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        Special_case0.SetActive(false);
        Special_case1.SetActive(false);
        Special_case2.SetActive(false);
        ShowStatistics(0);

    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeSpecialCase0()
    {
        
        special_case0_check = !special_case0_check;
        Special_case0.SetActive(special_case0_check);
    }

    public void ChangeSpecialCase1() // in this case, allow player to shoot, when freeze becomes unfreeze, shoots will be directed to targets
    {
        
        special_case1_check = !special_case1_check;
        Special_case1.SetActive(special_case1_check);
    }

    public void ChangeSpecialCase2() // in this case, allow player to shoot, when freeze becomes unfreeze, shoots will be directed to targets
    {
        special_case2_check = !special_case2_check;
        Special_case2.SetActive(special_case2_check);
        if(special_case2_check)
            gunController.maxBullet += 5;
        UpdateAmmoInfo(gunController.currentBullet, gunController.maxBullet);
    }
}
