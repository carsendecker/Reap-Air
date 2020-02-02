using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSound : MonoBehaviour {
    public AudioSource stepsSoundSource;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) {
            stepsSoundSource.Play();
        }
    }
}
