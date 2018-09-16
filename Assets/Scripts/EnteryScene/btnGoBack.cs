using UnityEngine;
using System.Collections;
using Custom;
using System;

public class btnGoBack : MonoBehaviour
{
    public GameObject InputManager;
    AudioSource sfxBack;
    // Use this for initialization

    void Awake()
    {
        sfxBack = GameObject.FindGameObjectWithTag("sfxBack").GetComponent<AudioSource>();
    }
    void Start()
    {
        InputManager.GetComponent<InputManagerScript>().P1_Select_Initiated += this.GoBack;
        //InputManager.GetComponent<InputManagerScript>().P2_Select_Initiated += this.GoBack;
        //InputManager.GetComponent<InputManagerScript>().P3_Select_Initiated += this.GoBack;
        //InputManager.GetComponent<InputManagerScript>().P4_Select_Initiated += this.GoBack;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoBack(object sender, EventArgs e)
    {
        sfxBack.Play();
        if (playersList.current.currentState == (int)GameStates.Introduction)
        {
            playersList.current.gameStates = GameStates.MainMenu;
        }
        else
        {
            playersList.current.gameStates = (GameStates)playersList.current.currentState - 1;//GameStates.TutorialState;
        }
        playersList.current.SwitchGame();// = GameStates.TutorialState;
    }
}
