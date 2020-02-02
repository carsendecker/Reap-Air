using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheBehavior : MonoBehaviour {
    public Collider2D enemyCollider;
    public bool attacking;
    public GameObject carbon;
    public GameObject oxygen;
    public GameObject scythe;

    // Start is called before the first frame update
    void Start() {
    
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Carbon" && attacking) {
            Destroy(other.gameObject);
        }

        if (other.tag == "Oxygen" && attacking) {
            attacking = false;
        }
    }
}
