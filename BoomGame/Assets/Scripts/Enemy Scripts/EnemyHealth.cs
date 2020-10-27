using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    public AudioClip death;
    
    void Update()
    {
        if(health <= 0) {
            Destroy(gameObject);
            SoundManager.instance.PlaySoundFX(death);
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Bullet") {
            health -= 20;
            Destroy(target.gameObject);
        }
    }
}
