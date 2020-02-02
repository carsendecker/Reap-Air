using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {
    public Canvas mainMainMenuController;
    public Canvas howToPlay;

    public GameObject mainMenuObjs;
    public GameObject howToPlayObjs;

    void Awake() {
        gameObject.GetComponent<MainMenuController>().currOption = MainMenuController.Option.Start;
        Debug.Log("Setting the original option");
    }

    void Update() {
        SelectOption();
    }

    //function to detect when the player presses return/enter and execute the action of the option it's on 
    //(continue or restart)
    public void SelectOption() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (gameObject.GetComponent<MainMenuController>().GetOption() == MainMenuController.Option.Start) {
                SceneManager.LoadScene(1);
            }

            //in this case, the HowToPlay choice will open the "How To Play" MainMenuController
            else if (gameObject.GetComponent<MainMenuController>().GetOption() == MainMenuController.Option.HowToPlay) {
                howToPlay.gameObject.SetActive(true);
                howToPlayObjs.gameObject.SetActive(true);

                gameObject.SetActive(false);
                mainMenuObjs.gameObject.SetActive(false);
            }
        }
    }
}
