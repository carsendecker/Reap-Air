using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToPlayer : MonoBehaviour
{
    [Range(0, 0.5f)] public float FlySpeed;
    public float FlyDelay;

    private Transform player;
    private Rigidbody2D rb;
    private bool startFlying;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(WaitToFly());
    }

    // Update is called once per frame
    void Update()
    {
        if (startFlying)
        {
            transform.right = player.position - transform.position;
            transform.position = Vector3.Lerp(transform.position, player.position, FlySpeed);
            FlySpeed *= 1.05f;
        }
    }

    IEnumerator WaitToFly()
    {
        yield return new WaitForSeconds(Random.Range(FlyDelay - 0.3f, FlyDelay + 0.3f));
        startFlying = true;
    }
    
    
}
