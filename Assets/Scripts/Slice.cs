using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour {
    public KeyCode AttackKey; // Input for Attacks
    public GameObject Scythe;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack() {
        if (Input.GetKeyDown(AttackKey)) {
            Scythe.transform.Rotate(new Vector3 (0, 0, 10));
            // Debug.Log("Clicked");
        }
    }
}
