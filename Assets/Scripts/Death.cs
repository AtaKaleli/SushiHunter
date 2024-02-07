using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GunController gunController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Target" || collision.tag == "Player")
        {
            UIManager.instance.OpenGameOverScreen();
            UIManager.instance.ShowStatistics(gunController.reloadTime, gunController.bulletsShooted);
        }
    }
}
