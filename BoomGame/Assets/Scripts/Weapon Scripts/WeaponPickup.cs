using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon;

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Player") {
            target.GetComponent<Shooting>().currentWeapon = weapon;
            target.GetComponent<Shooting>().currentWeapon.ammo = target.GetComponent<Shooting>().currentWeapon.reserveAmmo;
            target.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSpr;
            checkGunPlace();
            Destroy(gameObject);
        }
    }

    private void checkGunPlace() {
        GameObject player = GameObject.Find("Soldier");
        if(player.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite.name == "Shotgun") {
            player.transform.GetChild(2).transform.localPosition = new Vector3(0.0017f, 0.0871f, 0f);
            player.transform.GetChild(0).transform.localPosition = new Vector3(0.0193f, 0.204f, 0f);
            player.transform.GetChild(2).transform.localScale = new Vector3(0.86f, 0.89f, 0f);
        }
        else if(player.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite.name == "Pistol") {
            player.transform.GetChild(2).transform.localPosition = new Vector3(-0.009f, 0.06f, 0f);
            player.transform.GetChild(0).transform.localPosition = new Vector3(-0.002f, 0.1872f, 0f);
            player.transform.GetChild(2).transform.localScale = new Vector3(0.93f, 0.95f, 0f);
        }
    }
}
