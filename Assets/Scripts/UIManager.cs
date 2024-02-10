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
    [SerializeField] private GameObject seeBadgesPanel;
    [SerializeField] private GameObject moreInfoPanel;
    [SerializeField] private PoweshotSpawner powershotSpawner;

    [Header("Badges")]

    [SerializeField] private GameObject accuracyGold;
    [SerializeField] private GameObject accuracySilver;
    [SerializeField] private GameObject accuracyBronze;

    
    [SerializeField] private GameObject survivorGold;
    [SerializeField] private GameObject survivorSilver;
    [SerializeField] private GameObject survivorBronze;

    [SerializeField] private GameObject specialShotGold;
    [SerializeField] private GameObject specialShotSilver;
    [SerializeField] private GameObject specialShotBronze;

    [SerializeField] private GameObject hunterGold;
    [SerializeField] private GameObject hunterSilver;
    [SerializeField] private GameObject hunterBronze;
    
    private float accuracy;


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
        accuracy = bulletsConsumed > 0 ? (float)scoreValue / bulletsConsumed * 100 : 0f;


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
        CloseSpecialPanels();
        ShowStatistics(0);
    }

    public void SeeBadges()
    {
        AudioManager.instance.PlayButtonClickSFX();
        gameOverPanel.SetActive(false);
        seeBadgesPanel.SetActive(true);

        int netAccuracy = Mathf.RoundToInt(accuracy);
        int netTimer = Mathf.RoundToInt(timer);
        int netPowershot = powershotSpawner.powershotUsed;
        int netScore = scoreValue;

        ShowAccuracyBadge(netAccuracy);
        ShowTimerBadge(netTimer);
        ShowPowershotBadge(netPowershot);
        ShowHunterBadge(netScore);

    }

    private void ShowHunterBadge(int netScore)
    {
        if (netScore > 500)
            hunterGold.SetActive(true);
        else if (netScore < 500 && netScore > 200)
            hunterSilver.SetActive(true);
        else
            hunterBronze.SetActive(true);
    }

    private void ShowPowershotBadge(int netPowershot)
    {
        if (netPowershot < 10)
            specialShotGold.SetActive(true);
        else if (netPowershot > 10 && netPowershot < 30)
            specialShotSilver.SetActive(true);
        else
            specialShotBronze.SetActive(true);
    }

    private void ShowTimerBadge(int netTimer)
    {
        if (netTimer > 300)
            survivorGold.SetActive(true);
        else if (netTimer < 300 && netTimer > 120)
            survivorSilver.SetActive(true);
        else
            survivorBronze.SetActive(true);
    }

    private void ShowAccuracyBadge(int netAccuracy)
    {
        if (netAccuracy > 75)
            accuracyGold.SetActive(true);
        else if (netAccuracy < 75 && netAccuracy > 25)
            accuracySilver.SetActive(true);
        else
            accuracyBronze.SetActive(true);
    }

    public void BackToGameOverScreen()
    {
        AudioManager.instance.PlayButtonClickSFX();
        seeBadgesPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void OpenMoreInfo()
    {
        AudioManager.instance.PlayButtonClickSFX();
        seeBadgesPanel.SetActive(false);
        moreInfoPanel.SetActive(true);
    }

    public void BackToBadgesScreen()
    {
        AudioManager.instance.PlayButtonClickSFX();
        moreInfoPanel.SetActive(false);
        seeBadgesPanel.SetActive(true);
    }

    public void ExitGame()
    {
        AudioManager.instance.PlayButtonClickSFX();
        Application.Quit();
    }


    private void CloseSpecialPanels()
    {
        Special_case0.SetActive(false);
        Special_case1.SetActive(false);
        Special_case2.SetActive(false);
    }


    public void RestartGame()
    {
        AudioManager.instance.PlayButtonClickSFX();
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
