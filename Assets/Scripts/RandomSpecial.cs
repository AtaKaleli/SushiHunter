using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpecial : MonoBehaviour
{



    public bool checkDrag;

    private static int randomSpecialIndex = -1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            //int randomSpecialIndex = Random.Range(0, 3);
            randomSpecialIndex++;
            switch (randomSpecialIndex)
            {
                case 0:
                    AudioManager.instance.PlaySlowTimeSFX();
                    UIManager.instance.ChangeSpecialCase0();
                    Time.timeScale = 0.75f;
                    checkDrag = true;
                    StartCoroutine(TargetSlowDown());
                    break;

                case 1:
                    AudioManager.instance.PlayFreezeSFX();
                    UIManager.instance.ChangeSpecialCase1();
                    Time.timeScale = 0.001f;
                    StartCoroutine(StopTimer());
                    break;

                case 2:
                    AudioManager.instance.PlayAmmoAddedSFX();
                    UIManager.instance.ChangeSpecialCase2();
                    StartCoroutine(AddAmmo());
                    break;


                default:
                    break;
            }

        }

        else if (collision.tag == "DeathArea")
            Destroy(gameObject);
    }




    IEnumerator TargetSlowDown()
    {
        TeleportSpecial();
        yield return new WaitForSeconds(5.35f); // wait 8 seconds for slowing down the targets


        UIManager.instance.ChangeSpecialCase0();
        checkDrag = false;
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    IEnumerator StopTimer()
    {
        TeleportSpecial();
        yield return new WaitForSeconds(0.003f);
        UIManager.instance.ChangeSpecialCase1();
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    IEnumerator AddAmmo()
    {
        TeleportSpecial();
        yield return new WaitForSeconds(2f);
        UIManager.instance.ChangeSpecialCase2();
        Destroy(gameObject);
    }

    private void TeleportSpecial()
    {
        Rigidbody2D specialRB = GetComponent<Rigidbody2D>();
        specialRB.transform.position = new Vector3(0, -10, 0); // transfer object into somewhere like death area, dont destroy bc when destroyed, program dont works
    }
}
