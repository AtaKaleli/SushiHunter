using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{


    [SerializeField] private Sprite[] targetSprite;
    [SerializeField] private BoxCollider2D boxCD;
    [SerializeField] private GameObject targetPrefab;
    private float timer;
    [SerializeField] private float cooldown;

    private int sushiCreated = 0;
    private int sushiMilestone = 5;

    void Update()
    {

        timer -= Time.deltaTime;
        
        if (timer < 0)
        {
            sushiCreated++;
            print(sushiCreated);
            if(sushiCreated > sushiMilestone && cooldown> .55f)
            {
                sushiMilestone += 5;
                cooldown -= .3f;
            }

            GameObject newTarget = Instantiate(targetPrefab);

            float randomX = Random.Range(boxCD.bounds.min.x, boxCD.bounds.max.x);
            newTarget.transform.position = new Vector3(randomX, transform.position.y);

            int spriteIndex = Random.Range(0, targetSprite.Length);
            newTarget.GetComponent<SpriteRenderer>().sprite = targetSprite[spriteIndex];

           
            timer = cooldown;

        }

    }
}
