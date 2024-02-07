using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSpawner : MonoBehaviour
{
    
    [SerializeField] private BoxCollider2D boxCD;
    [SerializeField] private GameObject specialPrefab;
    private float timer = 0;
    [SerializeField] private int specialCooldown = 10;

  

    private void Awake()
    {
        timer = specialCooldown;

    }

    void Update()
    {

        timer -= Time.deltaTime;


        if (timer <= 0)
        {

            GameObject newTarget = Instantiate(specialPrefab);

            float randomX = Random.Range(boxCD.bounds.min.x, boxCD.bounds.max.x);
            newTarget.transform.position = new Vector3(randomX, transform.position.y);

            timer = specialCooldown;
            

            

            

        }

    }
}
