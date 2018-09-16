using UnityEngine;
using System.Collections;
using System;

public class GoNext : MonoBehaviour
{
    public GameObject InputManager;
    AudioSource sfxNext;
    // Use this for initialization
    void Start()
    {
        InputManager.GetComponent<InputManagerScript>().P1_START_Initiated += this.Next;
        sfxNext = GameObject.FindGameObjectWithTag("sfxNext").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Next(object sender, EventArgs e)
    {
        sfxNext.Play();
        Debug.Log(playersList.current.currentState);
        if (playersList.current.currentState == (int)GameStates.WinnerState)// || playersList.current.currentState == (int)GameStates.MoodTutorial) //12 -> WinnerScene
        {
            // playersList.current.gameStates = GameStates.MoodTutorial; //(GameStates)playersList.current.currentState + 1;
            playersList.current.gameStates = GameStates.GamePlayState;
        }
        else if (playersList.current.currentState == 1)//(int)GameStates.SplashState
        {
            playersList.current.gameStates = GameStates.MainMenu;
        }
        else
        {
            playersList.current.gameStates = (GameStates)playersList.current.currentState + 1;//
        }
        
        playersList.current.SwitchGame();// = GameStates.TutorialState;
    }
}
