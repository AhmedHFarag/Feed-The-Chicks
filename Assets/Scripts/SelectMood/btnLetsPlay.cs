using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class btnLetsPlay : MonoBehaviour
{
    // 03/05/2016 new select mood
    //public Transform SelectedGrid;
    public Transform SelectMood;
    //end
    public List<int> SelectedList;
    // Use this for initialization
    /* 20/4/2016 added code */
    public GameObject InputManager;

    AudioSource sfxNext;

    void Awake()
    {
        // 03/05/2016 new select mood
        //SelectedList = SelectMood.GetComponent<NavigateAndSelectMode1>().SelectedMoods;

        //End
        sfxNext = GameObject.FindGameObjectWithTag("sfxNext").GetComponent<AudioSource>();
    }
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
        OnClick();
    }
    /* 20/4/2016 end of added code */
    public void OnClick()
    {
        sfxNext.Play();
        // 03/05/2016 new select mood
        //SelectedList = new List<int>();
        //for (int i = 0; i < SelectedGrid.childCount; i++)
        //{
        //    SelectedList.Add(int.Parse(SelectedGrid.GetChild(i).name));
        //}

        SelectedList = SelectMood.GetComponent<NavigateAndSelectMode1>().SelectedMoods;
        SelectedList.Sort();
        Suffle(SelectedList);
        //End
        playersList.current.TotelNoOfMoods = SelectedList.Count;
        playersList.current.MoodsList = SelectedList;
        playersList.current.gameStates = GameStates.GamePlayState;
        // playersList.current.gameStates = GameStates.MoodTutorial;
        playersList.current.SwitchGame();// = GameStates.GamePlayState;
       

    }

    void Suffle(List<int> SelectedMoods)
    {
        System.Random rng = new System.Random();
        Debug.Log(rng);
        int n = SelectedMoods.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = SelectedMoods[k];
            SelectedMoods[k] = SelectedMoods[n];
            SelectedMoods[n] = value;
        }
    }
}
