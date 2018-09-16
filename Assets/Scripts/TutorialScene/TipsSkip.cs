using UnityEngine;
using System.Collections;
using System;

public class TipsSkip : MonoBehaviour {

	// Use this for initialization
    /* 20/4/2016 added code */
    public GameObject InputManager;
    // Use this for initialization
    void Start()
    {
        InputManager.GetComponent<InputManagerScript>().P1_START_Initiated += this.Accept;
        //InputManager.GetComponent<InputManagerScript>().P2_START_Initiated += this.Accept;
        //InputManager.GetComponent<InputManagerScript>().P3_START_Initiated += this.Accept;
        //InputManager.GetComponent<InputManagerScript>().P4_START_Initiated += this.Accept;
    }
    public void Accept(object sender, EventArgs e)
    {
        OnTipsSkip();
    }
    /* 20/4/2016 end of added code */
	
    public void OnTipsSkip()
    {
        Debug.Log("skip clicked");
        playersList.current.gameStates = GameStates.GamePlayState;
        playersList.current.SwitchGame();
    }
	// Update is called once per frame
	void Update () {
	
	}
    
}
