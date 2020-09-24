 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool sprint = false;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    [SerializeField]
    private int health;
    private bool hit = true;
    private Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift)) {
            moveSpeed = 7;
        }
        else
            moveSpeed = 5;

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;

        
    }

    IEnumerator HitBoxOff() {
        hit = false;
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Enemy") {
            if(hit) {
                StartCoroutine(HitBoxOff());
                health--;
                Destroy(GameObject.Find("Life-Box").transform.GetChild(0).gameObject);
            }
        }
    }
}
