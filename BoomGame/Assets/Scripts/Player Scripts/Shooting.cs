using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Weapon currentWeapon;
    public Transform firePoint;

    private float nextTimeOfFire = 0;

    void Update()
    {
        if(!PauseMenu.isPaused && !ReloadTimer.isReloading)
        {
            if (Input.GetMouseButton(0) && currentWeapon.ammo != 0)
            {
                if(Time.time >= nextTimeOfFire) {
                    currentWeapon.Shoot();
                    nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;
                }
            }

            else if (Input.GetKeyDown(KeyCode.R))
            {
                currentWeapon.Reload();
            }
        }
    }
}
