using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Custom;

using UnityEngine.SceneManagement;

public enum menuItems
{
    Introduction,
    play,
    settings,
    credits,
    quit,
}

public class MainmenuNavigationSelection : MonoBehaviour
{
    //public GameObject InpManOBJ;
    public InputManagerScript inputManager;
    public RectTransform menuList;

    public List<Button> menuBtns;
    menuItems item;
    int Index = 0;

    public Color UnSelectedColor = Color.white;

    public Button currentBtn;

    AudioSource sfxNavigate;
    AudioSource sfxSelect;
    AudioSource sfxNext;
    AudioSource sfxBack;

    //public AudioSource UINavigate;
    //public AudioSource UISelect;

    void Awake()
    {
        //inputManager = InpManOBJ.GetComponent<InputManagerScript>();
        //if (inputManager == null)
        //{
        //    inputManager = FindObjectOfType<InputManagerScript>();
        //}
        menuBtns = new List<Button>(menuList.childCount);
        for (int i = 0; i < (menuList.childCount); i++)
        {
            menuBtns.Add(menuList.GetChild(i).GetComponent<Button>());
        }

        currentBtn = menuBtns[0];
        ////currentBtn.Select();
        //ColorBlock cb = currentBtn.colors;
        //cb.normalColor = cb.highlightedColor;
        //currentBtn.colors = cb;
        ////currentBtn.colors.highlightedColor = SelectedColor;


        SpriteState cb = currentBtn.spriteState;
        currentBtn.image.sprite = cb.highlightedSprite;
        //currentBtn.colors = cb;

        sfxNavigate = GameObject.FindGameObjectWithTag("sfxNavigate").GetComponent<AudioSource>();
        sfxSelect   = GameObject.FindGameObjectWithTag("sfxSelect").GetComponent<AudioSource>();
       // sfxNext     = GameObject.FindGameObjectWithTag("sfxNext").GetComponent<AudioSource>();
        //sfxBack     = GameObject.FindGameObjectWithTag("sfxBack").GetComponent<AudioSource>();


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
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SelectItem(object sender, EventArgs e)
    {
        sfxSelect.Play();
        //item = (menuItems)currentBtn.name;
        switch (Index)
        {
            case (int)menuItems.play:
                playersList.current.gameStates = GameStates.PlayerSelectionState;
                playersList.current.SwitchGame();
                break;
            case (int)menuItems.Introduction:
                playersList.current.gameStates = GameStates.Introduction;
                playersList.current.SwitchGame();
                break;
            case (int)menuItems.settings:
                playersList.current.gameStates = GameStates.SettingsMenu;
                playersList.current.SwitchGame();
                break;
            case (int)menuItems.credits:
                //playersList.current.gameStates = GameStates.PlayerSelectionState;
                //playersList.current.SwitchGame();
                break;
            case (int)menuItems.quit:
                //playersList.current.gameStates = GameStates.PlayerSelectionState;
                //playersList.current.SwitchGame();
                Application.Quit();
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
        sfxNavigate.Play();
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

        //ColorBlock cb = currentBtn.colors;
        //cb.normalColor = UnSelectedColor;
        //currentBtn.colors = cb;

        //currentBtn = menuBtns[Index];

        //cb = currentBtn.colors;
        //cb.normalColor = cb.highlightedColor;
        //currentBtn.colors = cb;

        SpriteState cb = currentBtn.spriteState;
        currentBtn.image.sprite = cb.disabledSprite;
        //currentBtn.colors = cb;

        currentBtn = menuBtns[Index];

        cb = currentBtn.spriteState;
        currentBtn.image.sprite = cb.highlightedSprite;
        //currentBtn.colors = cb;


        //Debug.Log(currentBtn.name + " , " + currentBtn.colors.highlightedColor);
    }
}
