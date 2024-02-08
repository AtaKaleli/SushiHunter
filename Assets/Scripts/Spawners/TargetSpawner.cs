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
    public RandomSpecial randomSpecial;


    private void Awake()
    {
        timer = cooldown;

    }

    void Update()
    {

        timer -= Time.deltaTime;


        if (timer <= 0)
        {

            if (sushiCreated > sushiMilestone && cooldown > .55f)
            {
                sushiMilestone += 10;
                cooldown -= .3f;
            }

            GameObject newTarget = Instantiate(targetPrefab);

            float randomX = Random.Range(boxCD.bounds.min.x, boxCD.bounds.max.x);
            newTarget.transform.position = new Vector3(randomX, transform.position.y);

            int spriteIndex = Random.Range(0, targetSprite.Length);
            newTarget.GetComponent<SpriteRenderer>().sprite = targetSprite[spriteIndex];


            randomSpecial = FindObjectOfType<RandomSpecial>();//when special is created, take it, and check whether option0 is executed or not by checking randomSpecial.checkDrag
            if (randomSpecial != null && randomSpecial.checkDrag)
                ChangeLinearDrag(newTarget);






            sushiCreated++;
            timer = cooldown;

        }

    }

    public void ChangeLinearDrag(GameObject GO) // make drag of target 12 when special case0 is taken by player
    {

        Rigidbody2D rb = GO.GetComponent<Rigidbody2D>();

        if (randomSpecial.checkDrag)
            rb.drag = 12;
        else
            rb.drag = 5;

    }
}
