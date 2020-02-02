using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonDioxideMovement : MonoBehaviour {
    private Vector2 movement;
    private float speed;
    public Rigidbody2D rb;
    private int pushForce = 10;

    // Start is called before the first frame update
    void Start() {
        speed = Random.Range(-10f, 10f);
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void FixedUpdate() {
        rb.AddForce(movement * speed);

    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Wall") {
            Vector2 flingForce = Vector2.Reflect(movement, -other.transform.up);
            rb.AddForce(flingForce);
        }
    }
}