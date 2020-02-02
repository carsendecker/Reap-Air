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
    public SpriteRenderer sr;
    public float lerpSpeed = 0.4f;
    public ScytheBehavior sb;
    public AudioSource audioSource;
    public AudioClip punch;


    // Start is called before the first frame update
    void Start()
    {
        pc.GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        Facing direction = pc.FaceDir;

        if (Input.GetKeyDown(attackButton) && !midAttack) {

            midAttack = true;
            sb.attacking = true;
            StartCoroutine(Swing(direction));
            audioSource.PlayOneShot(punch);
        }

        if (pc.isFacingLeft) {
            sr.flipX = true;
        } else {
            sr.flipX = false;
        }
        
    }

    IEnumerator Swing(Facing dir) {
        switch(dir) {
            case Facing.Down:
                for (int i = 0; i < 120 / swingSpeed; i++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(-0.087f, -0.13f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 120f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 120 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0.166f, -0.10f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 1.2f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 240f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 120 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0f, 0f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 0f), lerpSpeed);
                    yield return 0;
                }
                break;
            case Facing.DownLeft:
                for (int i = 0; i < 120 / swingSpeed; i++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0.079f, -0.162f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, -swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 120f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 120 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(-0.154f, -0.044f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, -swingSpeed * 1.2f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 240f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 120 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0f, 0f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, -swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 0f), lerpSpeed);
                    yield return 0;
                }
                break;
            case Facing.DownRight:
                for (int i = 0; i < 120 / swingSpeed; i++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(-0.079f, -0.162f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 120f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 120 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0.154f, -0.044f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 1.2f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 240f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 120 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0f, 0f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 0f), lerpSpeed);
                    yield return 0;
                }
                break;
            case Facing.Right:
                for (int i = 0; i < 60 / swingSpeed; i++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0.188f, 0.008f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, -swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 120f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 80 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0.091f, -0.112f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, -swingSpeed * 1.2f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 240f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 220 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0f, 0f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, -swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 0f), lerpSpeed);
                    yield return 0;
                }
                break;
            case Facing.Left: 
                for (int i = 0; i < 60 / swingSpeed; i++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(-0.188f, 0.008f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 120f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 80 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(-0.091f, -0.112f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 1.2f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 240f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 220 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0f, 0f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 0f), lerpSpeed);
                    yield return 0;
                }
                break;
            case Facing.Up: 
                for (int i = 0; i < 40 / swingSpeed; i++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0.071f, 0.17f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, -swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 120f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 100 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(-0.128f, 0.054f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 1.2f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 240f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 300 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0f, 0f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 0f), lerpSpeed);
                    yield return 0;
                }
                scythe.transform.rotation = Quaternion.Euler(0f,0f,0f);
                break;
            case Facing.UpRight: 
                for (int i = 0; i < 240 / swingSpeed; i++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0.151f, 0.004f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 120f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 60 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(-0.096f, 0.123f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 1.2f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 240f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 60 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0f, 0f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 0f), lerpSpeed);
                    yield return 0;
                }
                scythe.transform.rotation = Quaternion.Euler(0f,0f,0f);
                break;
            case Facing.UpLeft: 
                for (int i = 0; i < 240 / swingSpeed; i++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(-0.151f, 0.004f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, -swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 120f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 60 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0.096f, 0.123f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, -swingSpeed * 1.2f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 240f), lerpSpeed);
                    yield return 0;
                }
                for (int i = 0; i < 60 / swingSpeed; i ++) {
                    scythe.transform.localPosition = Vector3.Lerp(scythe.transform.localPosition, new Vector3(0f, 0f, 0f), lerpSpeed);
                    scythe.transform.Rotate(new Vector3(0f, 0f, -swingSpeed * 0.9f));
                    // scythe.transform.localRotation = Quaternion.Slerp(scythe.transform.localRotation, Quaternion.Euler(0, 0, 0f), lerpSpeed);
                    yield return 0;
                }
                scythe.transform.rotation = Quaternion.Euler(0f,0f,0f);
                break;
        }
                
        midAttack = false;
        sb.attacking = false;
    }
}
