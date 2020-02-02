using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonDioxideMovement : MonoBehaviour {
    private Vector2 movement;
    private float speed;
    public Rigidbody2D rb;
    private int pushForce = 10;
    private float rotateRate;

    // Start is called before the first frame update
    void Start() {
        //get a random speed and rotation rate for each molecule
        speed = Random.Range(-10f, 10f);
        rotateRate = Random.Range(-90f, 90f);

        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }

    void Update() {
        Rotate(); 
        Move();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Wall") {
            Debug.Log("Colliding with wall and trying to bounce off of");
            Vector2 flingForce = Vector2.Reflect(movement, other.transform.up);
            rb.AddForce(flingForce);
        }
    }

    void Move() {
        rb.velocity = movement;
    }

    //each Carbon Dioxide molecule will rotate along the z-axis at a random rate
    void Rotate() {
        transform.Rotate (0,0,rotateRate * Time.deltaTime);
    }
}