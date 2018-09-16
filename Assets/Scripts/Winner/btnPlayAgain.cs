using UnityEngine;
using System.Collections;
using System;

public class btnPlayAgain : MonoBehaviour {

    /* 20/4/2016 added code */
    public GameObject InputManager;
    // Use this for initialization
    void Start()
    {
        InputManager.GetComponent<InputManagerScript>().P1_START_Initiated += this.Accept;
        InputManager.GetComponent<InputManagerScript>().P2_START_Initiated += this.Accept;
        InputManager.GetComponent<InputManagerScript>().P3_START_Initiated += this.Accept;
        InputManager.GetComponent<InputManagerScript>().P4_START_Initiated += this.Accept;
    }
    public void Accept(object sender, EventArgs e)
    {
        OnClick();
    }
    /* 20/4/2016 end of added code */
    public void OnClick()
    {
        Debug.Log("press play again");
        //playersList.current.gameStates = GameStates.MoodTutorial;
        playersList.current.gameStates = GameStates.GamePlayState;
        playersList.current.SwitchGame();
    }
}
