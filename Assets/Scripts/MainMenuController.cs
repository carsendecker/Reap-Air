using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour {
    public enum Option {
        Start,
        HowToPlay,
    }
    [HideInInspector]public Option currOption;
    
    //text elements
    public TextMeshProUGUI startText;
    public TextMeshProUGUI howToPlayText;

    private TextMeshProUGUI currText;
    private TextMeshProUGUI otherText;

    void Start() {
        currOption = Option.Start;
        currText = startText;
        otherText = howToPlayText;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
            currOption = ChangeOption(currOption);
        }
        BlinkText(currText);
    }

    //allow the player to change between the two options 
    private Option ChangeOption(Option nextOption) {
        if (nextOption == Option.Start) {
            nextOption = Option.HowToPlay;
            currText = howToPlayText;
            otherText = startText;
        }
        else if (nextOption == Option.HowToPlay) {
            nextOption = Option.Start;
            currText = startText;
            otherText = howToPlayText;
        }
        
        return nextOption;
    }

    //public Getter to tell the LevelManager (which handles restarting the level) what choices the player selected
    public Option GetOption() {
        return currOption;
    }

    //flash the text to let the player know which choice the pointer is currently on
    //other option is white text
    private void BlinkText(TextMeshProUGUI currText) {
        float time = Mathf.PingPong(Time.unscaledDeltaTime * 275f, 1f);
        currText.color = Color.Lerp(Color.white, Color.green, time);
        otherText.color = Color.white;
    }
}
