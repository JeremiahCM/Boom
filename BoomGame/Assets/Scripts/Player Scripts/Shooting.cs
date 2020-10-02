using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public static int ammo = 30;

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.isPaused && !ReloadTimer.isReloading)
        {
            if (Input.GetButtonDown("Fire1") && ammo != 0)
            {
                Shoot();
            }

            else if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        ammo--;
    }

    void Reload()
    {
        if (!ReloadTimer.isReloading && ammo != 30)
        {
            ReloadTimer.timeLeft = 2.5f;
            ReloadTimer.isReloading = true;
        }
    }
}
