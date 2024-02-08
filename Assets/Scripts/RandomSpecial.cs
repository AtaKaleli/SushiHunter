using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpecial : MonoBehaviour
{

    
    
    public bool checkDrag;
    



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {

            int randomSpecialIndex = 2;//Random.Range(0, 4);

            switch (randomSpecialIndex)
            {
                case 0:
                    UIManager.instance.ChangeSpecialCase0();
                    Time.timeScale = 0.75f;
                    checkDrag = true;
                    StartCoroutine(TargetSlowDown());
                    break;

                case 1:
                    UIManager.instance.ChangeSpecialCase1();
                    Time.timeScale = 0.001f;
                    StartCoroutine(StopTimer());
                    break;

                case 2:
                    UIManager.instance.ChangeSpecialCase2();
                    Destroy(gameObject);
                    break;


                default:
                    break;
            }
            
            
            
        }

        



        

        
    }

    IEnumerator TargetSlowDown()
    {
        Rigidbody2D specialRB = GetComponent<Rigidbody2D>();
        specialRB.transform.position = new Vector3(0, -10, 0); // transfer object into somewhere like death area, dont destroy bc when destroyed, program dont works
        yield return new WaitForSeconds(8f); // wait 8 seconds for slowing down the targets


        UIManager.instance.ChangeSpecialCase0();
        checkDrag = false;
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    IEnumerator StopTimer()
    {
        yield return new WaitForSeconds(0.005f);
        UIManager.instance.ChangeSpecialCase1();
        Time.timeScale = 1;
        Destroy(gameObject);
    }

}
