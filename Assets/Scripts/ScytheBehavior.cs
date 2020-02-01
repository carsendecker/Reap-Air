using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheBehavior : MonoBehaviour {
    public Collider2D enemyCollider;
    public bool invincible;
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
        if (other.tag == "Carbon" && !invincible) {
            Destroy(carbon);
        }

        if (other.tag == "Oxygen") {
            Debug.Log("Ox");
            scythe.transform.Rotate(new Vector3(0f, 0f, -10f));
            invincible = true;
        }
    }
}
