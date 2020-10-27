using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    int maxAmmo;
    public Text ammoDisplay;
    public Shooting shootingScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Soldier").GetComponent<Shooting>().currentWeapon.ammo = GameObject.Find("Soldier").GetComponent<Shooting>().currentWeapon.reserveAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = GameObject.Find("Soldier").GetComponent<Shooting>().currentWeapon.ammo.ToString() + " / " + GameObject.Find("Soldier").GetComponent<Shooting>().currentWeapon.reserveAmmo.ToString();
    }
}
