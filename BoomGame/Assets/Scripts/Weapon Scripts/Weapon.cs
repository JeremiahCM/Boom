using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeaponSpr;

    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 20;
    public int ammo = 30;
}
