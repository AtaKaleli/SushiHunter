using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public static Death instance;

    [SerializeField] private GunController gunController;
    [SerializeField] private GameObject playerGun;
    public bool isPlayerDead = false;
    
    
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Target" || collision.tag == "Player")
        {
            isDeath(true);
            playerGun.SetActive(false);
            UIManager.instance.OpenGameOverScreen();
            UIManager.instance.ShowStatistics(gunController.bulletsShooted);
        }
    }

    public void isDeath(bool death)
    {
        isPlayerDead = death;
    }
}
