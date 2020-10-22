using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Weapon currentWeapon;
    public Transform firePoint;

    private float nextTimeofFire = 0;

    void Update()
    {
        if(!PauseMenu.isPaused && !ReloadTimer.isReloading)
        {
            if (Input.GetButtonDown("Fire1") && currentWeapon.ammo != 0)
            {
                currentWeapon.Shoot();
            }

            else if (Input.GetKeyDown(KeyCode.R))
            {
                currentWeapon.Reload();
            }
        }
    }
}
