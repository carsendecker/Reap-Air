using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float YearLimit;
    public float CurrentYear;
    public float TimePassSpeed;

    [Space(10)] public TMP_Text YearText;

    private bool gameRunning = true;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        if(gameRunning)
            TimePasses();
    }

    private void TimePasses()
    {
        CurrentYear += Time.deltaTime * TimePassSpeed;
        YearText.text = CurrentYear.ToString("F0") + " AD";

        if (CurrentYear > YearLimit)
            GameLost();
    }

    private void GameLost()
    {
        Debug.Log("U lose");
        gameRunning = false;
    }
}
