using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
//    public Collider2D enemyCollider;
//    public bool invincible;
//    public GameObject carbon;
//    public GameObject oxygen;

    [Space(10)] public GameObject CParticle;
    public float ExplodeForce;

    // Start is called before the first frame update
    void Start() {
    
    }

    // Update is called once per frame
    void Update() {
//        if(Input.GetKeyDown(KeyCode.Space))
//            Die();
    }

  

    public void Die()
    {
        for(int i = 0; i < Random.Range(2, 4); i++)
        {
            GameObject particle = Instantiate(CParticle, transform.position, Quaternion.identity);
            particle.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * ExplodeForce, ForceMode2D.Impulse);
        }
        Destroy(gameObject);
    }
}
