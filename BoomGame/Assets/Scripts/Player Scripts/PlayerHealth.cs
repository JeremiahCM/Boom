using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float health;
    private bool hit = true;
    private Animator animator;
    public GameObject lifeRectangle;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        updateHealthBoxes();
    }

    void updateHealthBoxes() {
        int tempHealthBoxes = (int)(health / 10);
        int actualHealthBoxes = GameObject.Find("Life-Box").transform.childCount;
        
        while(tempHealthBoxes != actualHealthBoxes) {
            if(tempHealthBoxes < actualHealthBoxes) {
                for(int i = 0; i <= actualHealthBoxes - tempHealthBoxes; i++) {
                    Destroy(GameObject.Find("Life-Box").transform.GetChild(i).gameObject);
                    actualHealthBoxes--;
                }
            }
            else if(tempHealthBoxes > actualHealthBoxes) {
                for(int i = 0; i < tempHealthBoxes - actualHealthBoxes; i++) {
                    GameObject go = Instantiate(lifeRectangle, new Vector3(0,0,0), Quaternion.identity) as GameObject;
                    go.transform.SetParent(GameObject.Find("Life-Box").transform);
                    go.transform.localScale = new Vector3(1,1,1);
                    actualHealthBoxes++;
                }
            }
        }
    }

    IEnumerator HitBoxOff() {
        hit = false;
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Enemy") {
            GameObject soldier = GameObject.Find("Soldier");
            PlayerArmor playerArmor = soldier.GetComponent<PlayerArmor>();

            if(hit) {
                StartCoroutine(HitBoxOff());

                if (playerArmor.armor <= 0)
                {
                    health -= 20;
                }

                else
                {
                    playerArmor.ArmorReduction(20);
                }
            }
        }
    }
}
