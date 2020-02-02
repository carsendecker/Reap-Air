using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HowToPlay : MonoBehaviour {
    public TextMeshProUGUI returnToMain;

    public Canvas mainMenu;
    public GameObject mainMenuObjs;
    public GameObject howToPlayObjs;

    // Update is called once per frame
    void Update() {
        BlinkText();
        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("Returning to main menu");
            gameObject.SetActive(false);
            howToPlayObjs.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
            mainMenuObjs.gameObject.SetActive(true);
        }
    }

    private void BlinkText() {
        float time = Mathf.PingPong(Time.unscaledDeltaTime * 275f, 1f);
        returnToMain.color = Color.Lerp(Color.white, Color.green, time);
    }
}
