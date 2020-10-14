using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    int maxAmmo;
    public Text ammoDisplay;

    // Start is called before the first frame update
    void Start()
    {
        maxAmmo = Shooting.ammo;
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = Shooting.ammo.ToString() + " / " + maxAmmo.ToString();
    }
}
