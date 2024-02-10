using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweshotSpawner : MonoBehaviour
{
    [SerializeField] private float specialShotCooldown = 8;
    [SerializeField] private float flingForce = 500;
    [SerializeField] private GameObject bulletPref;
    private float timer;
    public int powershotUsed = 0;

    private void Awake()
    {
        timer = specialShotCooldown;
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && timer >= specialShotCooldown)
        {
            AudioManager.instance.PlaySpecialShotAudio();
            StartCoroutine(SpecialShot());
            timer = 0;
            powershotUsed++;

        }

        else if (Input.GetKeyDown(KeyCode.F) && timer < specialShotCooldown)
            AudioManager.instance.PlayNotYetSpecialShotAudio();

    }

    IEnumerator SpecialShot()
    {
        yield return new WaitForSeconds(1.25f);
        for (int i = 0; i < 18; i++)
        {
            float xCoordinate = i - 8.5f;
            GameObject newShoot = Instantiate(bulletPref, new Vector3(xCoordinate, -6, 0), Quaternion.identity);
            Rigidbody2D shootRB = newShoot.GetComponent<Rigidbody2D>();
            shootRB.AddForce(new Vector2(0, flingForce)); // Adjust the force or any other parameters as needed
            Destroy(newShoot, 5);
        }
        
    }


}
