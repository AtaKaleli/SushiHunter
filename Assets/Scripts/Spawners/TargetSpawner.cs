using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{


    [SerializeField] private Sprite[] targetSprite;
    [SerializeField] private BoxCollider2D boxCD;
    [SerializeField] private GameObject targetPrefab;
    private float timer;
    [SerializeField] private float cooldown = 2;

    private int sushiCreated = 0;
    private int sushiMilestone = 10;

    private void Awake()
    {
        timer = cooldown;
    }

    void Update()
    {

        timer -= Time.deltaTime;
        

        if (timer <= 0)
        {
           
            if(sushiCreated > sushiMilestone && cooldown> .55f)
            {
                sushiMilestone += 10;
                cooldown -= .3f;
            }

            GameObject newTarget = Instantiate(targetPrefab);

            float randomX = Random.Range(boxCD.bounds.min.x, boxCD.bounds.max.x);
            newTarget.transform.position = new Vector3(randomX, transform.position.y);

            int spriteIndex = Random.Range(0, targetSprite.Length);
            newTarget.GetComponent<SpriteRenderer>().sprite = targetSprite[spriteIndex];
           
            sushiCreated++;
            
            timer = cooldown;

        }

    }
}
