using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Custom;
using System;


public enum SettingMenuItems
{
    audio,
    controls,
    help,
    video,
}
public class SettingMenuNavigationSelection : MonoBehaviour
{
    public InputManagerScript inputManager;
    public RectTransform menuList;

    public List<Button> menuBtns;
    menuItems item;
    int Index = 0;

    public Color UnSelectedColor = Color.white;

    public Button currentBtn;
    public Slider Sound;
    public Slider Sfx;
    GameObject PlayerList;
    void Awake()
    {
        if (inputManager == null)
        {
            inputManager = FindObjectOfType<InputManagerScript>();
        }
        menuBtns = new List<Button>(menuList.childCount);
        for (int i = 0; i < (menuList.childCount); i++)
        {
            menuBtns.Add(menuList.GetChild(i).GetComponent<Button>());
        }

        currentBtn = menuBtns[0];
        //currentBtn.Select();
        ColorBlock cb = currentBtn.colors;
        cb.normalColor = cb.highlightedColor;
        currentBtn.colors = cb;
        //currentBtn.colors.highlightedColor = SelectedColor;

        //Debug.Log(currentBtn.name + " , " + currentBtn.colors.highlightedColor);
    }
    // Use this for initialization
    void Start()
    {
        //inputManager.P2jumpInitiated += this.SelectItem;
        //inputManager.P3jumpInitiated += this.SelectItem;
        //inputManager.P4jumpInitiated += this.SelectItem;
        inputManager.P1jumpInitiated += this.SelectItem;

        inputManager.P1movementChanged += this.Navigate;
        //inputManager.P2movementChanged += this.Navigate;
        //inputManager.P3movementChanged += this.Navigate;
        //inputManager.P4movementChanged += this.Navigate;
        PlayerList = GameObject.FindGameObjectWithTag("PlayerList");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SelectItem(object sender, EventArgs e)
    {
        //item = (menuItems)currentBtn.name;
        Debug.Log("menuBtn Index: " + Index);
        switch (Index)
        {
            case (int)SettingMenuItems.audio:
                Debug.Log("audio state");
                //playersList.current.gameStates = GameStates.PlayerSelectionState;
                //playersList.current.SwitchGame();
                break;
            case (int)SettingMenuItems.controls:
                Debug.Log("controls state");
                //playersList.current.gameStates = GameStates.SettingsMenu;
                //playersList.current.SwitchGame();
                break;
            case (int)SettingMenuItems.help:
                Debug.Log("help state");
                //playersList.current.gameStates = GameStates.PlayerSelectionState;
                //playersList.current.SwitchGame();
                break;
            case (int)SettingMenuItems.video:
                Debug.Log("video state");
                //playersList.current.gameStates = GameStates.PlayerSelectionState;
                //playersList.current.SwitchGame();
                break;
        }
    }

    void Navigate(object sender, MovementEventArgs e)
    {
        if (Mathf.Abs(e.YAxis) > 0.2f)
        {
            NavigateBetweenItemsInList(((e.YAxis > 0) ? 1 : ((e.YAxis == 0) ? 0 : -1)));
        }
    }

    public void NavigateBetweenItemsInList(float Val)
    {
        Debug.Log(Val);
        //if (menuList.childCount < 2) { return; }
        if (Val > 0)
        {
            Index = (Index == menuList.childCount - 1) ? 0 : Index + 1;
        }
        else
        {
            Index = (Index == 0) ? menuList.childCount - 1 : Index - 1;
        }
        Debug.Log(Index);

        ColorBlock cb = currentBtn.colors;
        cb.normalColor = UnSelectedColor;
        currentBtn.colors = cb;

        currentBtn = menuBtns[Index];

        cb = currentBtn.colors;
        cb.normalColor = cb.highlightedColor;
        currentBtn.colors = cb;

        //Debug.Log(currentBtn.name + " , " + currentBtn.colors.highlightedColor);
    }
    public void Update_Sound()
    {
        PlayerList.GetComponent<playersList>().Set_Bg_Sound_Volum((int)Sound.value);
        PlayerList.GetComponent<playersList>().Set_Sfx_Sound_Volum((int)Sfx.value);
    }
}
