using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpecial : MonoBehaviour
{


    [SerializeField] private float specialCooldown = 5;
    public bool checkDrag;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {

            int randomSpecialIndex = 0; //Random.Range(0, 4);

            switch (randomSpecialIndex)
            {
                case 0:
                    Time.timeScale = 0.75f;
                    checkDrag = true;
                    StartCoroutine(SpecialCount());
                    break;


                default:
                    break;
            }
            
            
            
        }

        



        

        
    }

    IEnumerator SpecialCount()
    {


        
        Rigidbody2D specialRB = GetComponent<Rigidbody2D>();
        specialRB.transform.position = new Vector3(0, -10, 0); // transfer object into somewhere like death area, dont destroy bc when destroyed, program dont works
        yield return new WaitForSeconds(8f); // wait 8 seconds for slowing down the targets
      
        

        checkDrag = false;
        Time.timeScale = 1;
        Destroy(gameObject);
    }

}
