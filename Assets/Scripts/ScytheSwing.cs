using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheSwing : MonoBehaviour {
    public KeyCode attackButton = KeyCode.Space;
    public int direction = 0;
    public bool midAttack;
    public GameObject scythe;
    public float swingSpeed = 3;
    public PlayerController pc;


    // Start is called before the first frame update
    void Start()
    {
        pc.GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(attackButton) && !midAttack) {
            midAttack = true;
            StartCoroutine(Swing());
        }
        
    }

    IEnumerator Swing() {
        for (int i = 0; i < 120 / swingSpeed; i++) {
            scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed / 2));
            yield return 0;
        }
        for (int i = 0; i < 120 / swingSpeed; i++) {
            scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 2));
            yield return 0;
        }
        for (int i = 0; i < 120 / swingSpeed; i++) {
            scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed / 2));
            yield return 0;
        }
        midAttack = false;
    }
}
