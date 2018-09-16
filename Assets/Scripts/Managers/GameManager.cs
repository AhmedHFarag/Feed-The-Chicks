using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Custom;
using System;

//enum GameStates
//{
//    EnteryState,
//    MainMenuState,
//    SelectPlayerState,
//    SelectRoundState,
//    GamePlayState,
//}

public class GameManager : MonoBehaviour
{
    public static GameManager Current;

    public GameObject InputManager;
    GameStates gameStates;

    public GameObject[] playersUI;

    int UiCounter = 0;
    int UiCounterSwitch = 0;

    [HideInInspector]
    public List<int> players;

    void Awake()
    {
        if (Current == null)
        {
            //DontDestroyOnLoad(gameObject);
            Current = this;
        }
        else if (Current != this)
        {
            //Destroy(gameObject);
        }

        //gameStates = new GameStates();
        //gameStates = GameStates.SelectPlayerState;

        ////Get Input From All JoySticks 
        //InputManager.GetComponent<InputManagerScript>().P1movementChanged += this.Swich;
        //InputManager.GetComponent<InputManagerScript>().P2movementChanged += this.Swich;
        //InputManager.GetComponent<InputManagerScript>().P3movementChanged += this.Swich;
        //InputManager.GetComponent<InputManagerScript>().P4movementChanged += this.Swich;
        ////InputManager.GetComponent<InputManagerScript>().P1jumpInitiated += this.Jump;
        ////InputManager.GetComponent<InputManagerScript>().P2jumpInitiated += this.Jump;

        InputManager.GetComponent<InputManagerScript>().P1movementChanged += this.Select;
        InputManager.GetComponent<InputManagerScript>().P2movementChanged += this.Select;
        InputManager.GetComponent<InputManagerScript>().P3movementChanged += this.Select;
        InputManager.GetComponent<InputManagerScript>().P4movementChanged += this.Select;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Select(object sender, MovementEventArgs e)
    {
        if (Mathf.Abs(e.YAxis) >= 0.1) { return; }
        UiCounter++;
        players.Add(e.JoyStickID);
        switch (e.JoyStickID)
        {
            case 1:
                InputManager.GetComponent<InputManagerScript>().P1movementChanged += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch;
                playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch(sender,e);
                InputManager.GetComponent<InputManagerScript>().P1jumpInitiated += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Accept;
                InputManager.GetComponent<InputManagerScript>().P1jumpInitiated -= this.Select;
                InputManager.GetComponent<InputManagerScript>().P1movementChanged -= this.Select;
                break;
            case 2:
                InputManager.GetComponent<InputManagerScript>().P2movementChanged += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch;
                playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch(sender, e);
                InputManager.GetComponent<InputManagerScript>().P2jumpInitiated += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Accept;
                InputManager.GetComponent<InputManagerScript>().P2jumpInitiated -= this.Select;
                InputManager.GetComponent<InputManagerScript>().P2movementChanged -= this.Select;
                break;
            case 3:
                InputManager.GetComponent<InputManagerScript>().P3movementChanged += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch;
                playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch(sender, e);
                InputManager.GetComponent<InputManagerScript>().P3jumpInitiated += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Accept;
                InputManager.GetComponent<InputManagerScript>().P3jumpInitiated -= this.Select;
                InputManager.GetComponent<InputManagerScript>().P3movementChanged -= this.Select;
                break;
            case 4:
                InputManager.GetComponent<InputManagerScript>().P4movementChanged += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch;
                playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch(sender, e);
                InputManager.GetComponent<InputManagerScript>().P4jumpInitiated += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Accept;
                InputManager.GetComponent<InputManagerScript>().P4jumpInitiated -= this.Select;
                InputManager.GetComponent<InputManagerScript>().P4movementChanged -= this.Select;
                break;
            default:
                break;
        }
    }
    //void Jump(object sender, EventArgs e)
    //{

    //}
    //31/5/2016 
    //void Swich(object sender, MovementEventArgs e)
    //{
    //    if (Mathf.Abs(e.YAxis) >= 0.1) { return; }
    //    UiCounter++;
    //    //players.Add(e.JoyStickID);
    //    Debug.Log(e.JoyStickID);
    //    switch (e.JoyStickID)
    //    {
    //        case 1:
    //            InputManager.GetComponent<InputManagerScript>().P1movementChanged += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch;
    //            //InputManager.GetComponent<InputManagerScript>().P1jumpInitiated += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Accept;
    //            InputManager.GetComponent<InputManagerScript>().P1movementChanged -= this.Swich;
    //            break;
    //        case 2:
    //            InputManager.GetComponent<InputManagerScript>().P2movementChanged += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch;
    //            //InputManager.GetComponent<InputManagerScript>().P2jumpInitiated += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Accept;
    //            InputManager.GetComponent<InputManagerScript>().P2movementChanged -= this.Swich;
    //            break;
    //        case 3:
    //            InputManager.GetComponent<InputManagerScript>().P3movementChanged += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch;
    //            //InputManager.GetComponent<InputManagerScript>().P3jumpInitiated += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Accept;
    //            InputManager.GetComponent<InputManagerScript>().P3movementChanged -= this.Swich;
    //            break;
    //        case 4:
    //            InputManager.GetComponent<InputManagerScript>().P4movementChanged += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Switch;
    //            //InputManager.GetComponent<InputManagerScript>().P4jumpInitiated += playersUI[UiCounter - 1].GetComponent<SwitchPlayerUIBehaviour>().Accept;
    //            InputManager.GetComponent<InputManagerScript>().P4movementChanged -= this.Swich;
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
