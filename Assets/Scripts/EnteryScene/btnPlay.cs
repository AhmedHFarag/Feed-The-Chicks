using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using Custom;

public class btnPlay : MonoBehaviour
{
    public Image[] playerImages;

    public GameObject playerList;
    public List<int> playerAvatar;

    List<ChickenControllerData> playerDataList;

    List<Color> playerColorList = new List<Color>();
    /* 20/4/2016 added code */
    public GameObject InputManager;
    int ProceedCount = 0;

    AudioSource sfxNext;
    AudioSource sfxSelect;

    void Awake()
    {
        if (playerList == null)
        {
            playerList = GameObject.FindObjectOfType<playersList>().gameObject;

            sfxSelect = GameObject.FindGameObjectWithTag("sfxSelect").GetComponent<AudioSource>();
            sfxNext = GameObject.FindGameObjectWithTag("sfxNext").GetComponent<AudioSource>();
        }
    }
    void Start()
    {
        InputManager.GetComponent<InputManagerScript>().P1_START_Initiated += this.Accept;
        //InputManager.GetComponent<InputManagerScript>().P2_START_Initiated += this.Accept;
        //InputManager.GetComponent<InputManagerScript>().P3_START_Initiated += this.Accept;
        //InputManager.GetComponent<InputManagerScript>().P4_START_Initiated += this.Accept;

        InputManager.GetComponent<InputManagerScript>().P1jumpInitiated += this.PlayerChosen;
        InputManager.GetComponent<InputManagerScript>().P2jumpInitiated += this.PlayerChosen;
        InputManager.GetComponent<InputManagerScript>().P3jumpInitiated += this.PlayerChosen;
        InputManager.GetComponent<InputManagerScript>().P4jumpInitiated += this.PlayerChosen;

        InputManager.GetComponent<InputManagerScript>().P1movementChanged += this.PlayerUnSelected;
        InputManager.GetComponent<InputManagerScript>().P2movementChanged += this.PlayerUnSelected;
        InputManager.GetComponent<InputManagerScript>().P3movementChanged += this.PlayerUnSelected;
        InputManager.GetComponent<InputManagerScript>().P4movementChanged += this.PlayerUnSelected;
    }
    public void Accept(object sender, EventArgs e)
    {
        sfxNext.Play();

        if (ProceedCount > 1)
        {
            Debug.Log("Accept working");
            //OnClick();
            StartCoroutine(callClick());
        }
        else
        {
            Debug.Log("Accept not working");
        }
    }

    public void PlayerChosen(object sender, MovementEventArgs e)
    {
        sfxSelect.Play();
        ProceedCount++;
        switch (e.JoyStickID)
        {
            case 1:
                InputManager.GetComponent<InputManagerScript>().P1jumpInitiated -= this.PlayerChosen;
                //InputManager.GetComponent<InputManagerScript>().P1_X_Initiated += this.PlayerUnSelected;
                break;
            case 2:
                InputManager.GetComponent<InputManagerScript>().P2jumpInitiated -= this.PlayerChosen;
                //InputManager.GetComponent<InputManagerScript>().P2_X_Initiated += this.PlayerUnSelected;
                break;
            case 3:
                InputManager.GetComponent<InputManagerScript>().P3jumpInitiated -= this.PlayerChosen;
                //InputManager.GetComponent<InputManagerScript>().P3_X_Initiated += this.PlayerUnSelected;
                break;
            case 4:
                InputManager.GetComponent<InputManagerScript>().P4jumpInitiated -= this.PlayerChosen;
                //InputManager.GetComponent<InputManagerScript>().P4_X_Initiated += this.PlayerUnSelected;
                break;
            default:
                break;
        }
    }

    public void PlayerUnSelected(object sender, MovementEventArgs e)
    {
        ProceedCount--;
        switch (e.JoyStickID)
        {
            case 1:
                InputManager.GetComponent<InputManagerScript>().P1jumpInitiated += this.PlayerChosen;
                // InputManager.GetComponent<InputManagerScript>().P1movementChanged -= this.PlayerUnSelected;
                break;
            case 2:
                InputManager.GetComponent<InputManagerScript>().P2jumpInitiated += this.PlayerChosen;
                // InputManager.GetComponent<InputManagerScript>().P2movementChanged -= this.PlayerUnSelected;
                break;
            case 3:
                InputManager.GetComponent<InputManagerScript>().P3jumpInitiated += this.PlayerChosen;
                // InputManager.GetComponent<InputManagerScript>().P3movementChanged -= this.PlayerUnSelected;
                break;
            case 4:
                InputManager.GetComponent<InputManagerScript>().P4jumpInitiated += this.PlayerChosen;
                // InputManager.GetComponent<InputManagerScript>().P4movementChanged -= this.PlayerUnSelected;
                break;
            default:
                break;
        }
    }
    /* 20/4/2016 end of added code */

    public IEnumerator callClick()
    {
        yield return new WaitForSeconds(0.1f);
        OnClick();
    }
    public void OnClick()
    {
        playersList playersListConponenet = playerList.GetComponent<playersList>();
        Debug.Log(playerImages.Length);
        for (int i = 0; i < playerImages.Length; i++)
        {
            //Animator
            Debug.Log(playerImages[i].sprite.name);
            string[] avatarName = playerImages[i].sprite.name.Split('_');
            //switch (playerImages[i].sprite.name)
            switch (avatarName[0].ToLower())
            {
                //case "Red_idel_0":
                case "red":
                    playerAvatar.Add(0);
                    playerColorList.Add(new Color(1, 0, 0, 1));//get color from artist
                    break;
                //case "Blue_idel_0":
                case "blue":
                    playerAvatar.Add(1);
                    playerColorList.Add(new Color(0, .2f, .7f, 1));
                    break;
                //case "Purpul_idel_0":
                case "purpul":
                    playerAvatar.Add(2);
                    playerColorList.Add(Color.magenta);
                    break;
                //case "Green_idel_0":
                case "green":
                    playerAvatar.Add(3);
                    playerColorList.Add(Color.green);
                    break;
                case "yellow":
                    playerAvatar.Add(4);
                    playerColorList.Add(Color.yellow);
                    break;
            }
        }

        playersListConponenet.PlayerList = GameManager.Current.players;
        playersListConponenet.AvatarList = playerAvatar;

        Debug.Log(GameManager.Current.players);

        for (int i = 0; i < GameManager.Current.players.Count; i++)
        {
            ChickenControllerData playerData = new ChickenControllerData();
            playerData.ChickedId = GameManager.Current.players[i];
            playerData.ChickenColor = playerColorList[i];

            playersListConponenet.ChickenControllerDataList.Add(playerData);
            Debug.Log(playerData.ChickedId + " , " + playerData.ChickenColor);
            Debug.Log(GameManager.Current.players[i]);
            Debug.Log(playerAvatar[i]);
        }

        St();


    }

    void St()
    {
        //    //yield return new WaitForSeconds(1);
        //    Scene SceneToCheck = SceneManager.GetSceneByName("FeedTheChicksMode");
        //    if (!SceneToCheck.isLoaded)
        //    {
        //        SceneManager.LoadSceneAsync("FeedTheChicksMode", LoadSceneMode.Single);
        //        //StartCoroutine(MoveObject());
        //    }

        playersList.current.gameStates = GameStates.TutorialState;
        playersList.current.SwitchGame();// = GameStates.TutorialState;

    }
    //IEnumerator MoveObject()
    //{
    //    Scene SceneToCheck = SceneManager.GetSceneByName("FeedTheChicksMode");
    //    while (!SceneToCheck.IsValid())
    //    {
    //        yield return null;
    //    }
    //    SceneManager.MoveGameObjectToScene(playerList, SceneToCheck);
    //    //CameraBehaviour.GetCameraBehaviour().ResizeCamer (new Vector3(5,5,0),10);
    //}
}
