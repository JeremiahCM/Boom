using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;

    private Transform playerPos;
    public int health;

    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) > 0.5f)
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Bullet") {
            health--;

            if(health <= 0) {
                Destroy(gameObject, 0.05f);
            }
        }
    }
}
