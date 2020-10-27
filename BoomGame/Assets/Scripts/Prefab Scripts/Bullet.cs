using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public GameObject hitEffect;

    private void OnDestroy() {
        if(hitEffect == null) {
            Destroy(gameObject, 5f);
        }
        else {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
    }

    void Start() {
        Destroy(gameObject, 3);
    }
}
