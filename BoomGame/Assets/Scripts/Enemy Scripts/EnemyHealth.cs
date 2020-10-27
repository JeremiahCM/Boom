using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    
    void Update()
    {
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Bullet") {
            health -= GameObject.Find("Soldier").GetComponent<Shooting>().currentWeapon.damage;
            Destroy(target.gameObject);
        }
    }
}
