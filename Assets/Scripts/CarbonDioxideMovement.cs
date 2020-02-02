using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonDioxideMovement : MonoBehaviour {
    private Vector2 movement;
    private float speed;
    public Rigidbody2D rb;
    private int pushForce = 10;
    private float rotateRate;
    private Vector2 lastVel;

    private float destTimer;

    // Start is called before the first frame update
    void Start() {
        //get a random speed and rotation rate for each molecule
        speed = Random.Range(-10f, 10f);
        rotateRate = Random.Range(-90f, 90f);
        destTimer = Random.Range(1f, 4f);

        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        StartCoroutine(NewDestination());
    }

    void Update() {
        Rotate(); 
        //Move();
    }

    IEnumerator NewDestination() {
        rb.AddForce(movement, ForceMode2D.Impulse);
        yield return new WaitForSeconds(destTimer);
        StartCoroutine(NewDestination());
    }

    private Vector2 GetNewDestination() {
        Debug.Log("Changing directions");
        Vector2 newDestination = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        return newDestination;
    }

    // void Move() {
    //     rb.velocity = movement;
    // }

    //each Carbon Dioxide molecule will rotate along the z-axis at a random rate
    void Rotate() {
        transform.Rotate(0,0,rotateRate * Time.deltaTime);
    }
}