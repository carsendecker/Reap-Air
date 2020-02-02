using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheBehavior : MonoBehaviour {
    public Collider2D enemyCollider;
    public bool attacking;
    public GameObject carbon;
    public GameObject oxygen;
    public GameObject scythe;
    public AudioClip wrongHit;
    private AudioSource aso;

    // Start is called before the first frame update
    void Start() {
    
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Carbon" && attacking) {
            other.transform.GetComponent<EnemyBehavior>().Die();

            // DEATH PARTICLES
        }

        if (other.tag == "Oxygen" && attacking) {
            attacking = false;
            other.transform.parent.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position) * 5f, ForceMode2D.Impulse);
            aso.PlayOneShot(wrongHit);
        }
    }
}
