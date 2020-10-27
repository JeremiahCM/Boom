using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeaponSpr;
    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 20;
    public int reserveAmmo = 30;
    public int ammo = 30;

    public AudioClip[] shootClips;

    public void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("firePoint").transform.position, Quaternion.Euler(0,0,GameObject.Find("Soldier").GetComponent<Rigidbody2D>().rotation));
        if(bullet.transform.childCount > 0) {
            foreach (Transform child in bullet.transform) {
                Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
                rb.AddForce(GameObject.Find("firePoint").transform.up * 30, ForceMode2D.Impulse);
            }
        }
        else {
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(GameObject.Find("firePoint").transform.up * 30, ForceMode2D.Impulse);
        }
        ammo--;

        SoundManager.instance.PlaySoundFX(shootClips[Random.Range(0, shootClips.Length)]);
    }

    public void Reload()
    {
        if (!ReloadTimer.isReloading && ammo != 30)
        {
            ReloadTimer.timeLeft = 2.5f;
            ReloadTimer.isReloading = true;
        }
    }
}
