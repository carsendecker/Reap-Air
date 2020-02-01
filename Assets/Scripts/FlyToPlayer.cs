using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToPlayer : MonoBehaviour
{
    [Range(0, 0.5f)]
    public float FlySpeed;

    private Transform player;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
//        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = player.position - transform.position;
        transform.position = Vector3.Lerp(transform.position, player.position, FlySpeed);
        FlySpeed *= 1.05f;
    }
    
    
}
