using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private Animator gunAnim;
    [SerializeField] private float gunDistance = 1.5f;
    private bool gunFacingRight = true;
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private float bulletSpeed;

    private int currentBullet;
    [SerializeField] private int maxBullet = 15;

    void Start()
    {
        Reload();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // mouse position
        Vector3 direction = mousePos - transform.position;

        gun.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg)); // gun rotation

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(gunDistance, 0, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0) && HaveBullets())
        {
            Shoot(direction);
        }

        GunFlipController(mousePos);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

    }

    public void GunFlipController(Vector3 mousePos)
    {
        if (mousePos.x < gun.position.x && gunFacingRight)
            GunFlip();
        else if (mousePos.x > gun.position.x && !gunFacingRight)
            GunFlip();
    }

    private void Shoot(Vector3 direction)
    {
        UIManager.instance.UpdateAmmoInfo(currentBullet, maxBullet);
        gunAnim.SetTrigger("shoot");
        GameObject newBullet = Instantiate(bulletPref, gun.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        Destroy(newBullet, 5);


    }

    private void GunFlip()
    {
        gunFacingRight = !gunFacingRight;
        gun.localScale = new Vector3(gun.localScale.x, gun.localScale.y * -1, gun.localScale.z);
    }

    private void Reload()
    {
        currentBullet = maxBullet;
        UIManager.instance.UpdateAmmoInfo(currentBullet, maxBullet);
    }

    private bool HaveBullets()
    {
        if (currentBullet <= 0)
            return false;

        currentBullet--;
        return true;

    }


}
