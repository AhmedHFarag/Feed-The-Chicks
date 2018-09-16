using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public enum GameRuning
{
    Paused,
    Runing,
    Loaded,
}

public enum GameStates
{
    SplashState,
    MainMenu,
    SettingsMenu,
    PlayerSelectionState,
    TutorialState,
    SelectModeState,
    MoodTutorial,
    GamePlayState,
    WinnerState = 10,
    Introduction,
    // InnerWinner,
}

public enum GameMoods
{
    feedTheChicksMood = 6,
    RaceMood,
    FryPanMood,
    FallingBlocks,
}

public enum GameBGMusic
{
    // SplashMusic,
    MainMenuMusic,
    ModesMusic,
    //WinnerMusic,
}

//public enum MoodsTutorial
//{
//    FTCTutorial = 6,
//    ObstacleRaceTutorial = 7,
//    FryPanMoodTutorial = 8,
//}

public class playersList : MonoBehaviour
{

    public static playersList current;

    public List<int> PlayerList;//controlles
    public List<int> AvatarList;

    public List<int> MoodsList;
    public int TotelNoOfMoods;

    public GameStates gameStates;
    public GameMoods gameMoods;
    // public MoodsTutorial moodsTuorial;
    public int currentState;

    public int FinalWinnerID;
    //public GameObject FinalWinner;

    public Color FinalWinnerColor;
    //
    public Dictionary<int, float> playersScoreList;
    public Dictionary<int, float> orderedScoreDic;
    //List<ChickenController> playerControllerList;

    public List<ChickenControllerData> ChickenControllerDataList;


    //Sounds

    public float bg_Sound = 1;
    public float sfx_Sound = 1;

    //pause
    public bool isPaused = false;

    public float Bg_Sound = 100;
    public float Sfx_Sound = 100;
    AudioSource Music_AudioSorce;


    public bool EndofAllRounds=false;

    [SerializeField]
    GameObject MusicHolder;
    [HideInInspector]
    public AudioSource[] GameBGSound;
    

    // Use this for initialization
    void Awake()
    {
        //if(current == null)
        DontDestroyOnLoad(gameObject);
        current = this;

        gameStates = new GameStates();
        gameStates = GameStates.SplashState;
        ChickenControllerDataList = new List<ChickenControllerData>();

        Music_AudioSorce = GameObject.FindGameObjectWithTag("BGSOUND").GetComponent<AudioSource>();

        GameBGSound = new AudioSource[MusicHolder.transform.childCount];

        for (int i = 0; i < GameBGSound.Length; i++)
        {
            GameBGSound[i] = MusicHolder.transform.GetChild(i).GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Update_Sound();
    }

    public void SwitchGame()
    {

        switch (gameStates)
        {
            case GameStates.SplashState:
                {
                    //SceneManager.LoadScene((int)GameStates.SplashState, LoadSceneMode.Single);
                    currentState = (int)GameStates.SplashState;
                    GameBGSound[(int)GameBGMusic.MainMenuMusic].enabled = true;
                    break;
                }
            case GameStates.MainMenu:
                {
                    currentState = (int)GameStates.MainMenu;

                    SceneManager.LoadScene((int)GameStates.MainMenu, LoadSceneMode.Single);
                    break;
                }
            case GameStates.SettingsMenu:
                {
                    currentState = (int)GameStates.SettingsMenu;
                    SceneManager.LoadScene((int)GameStates.SettingsMenu, LoadSceneMode.Single);
                    break;
                }
            case GameStates.PlayerSelectionState:
                {
                    ChickenControllerDataList.Clear();
                    //3lshan yrga3 3ala main menu 3ala tool 
                    currentState = (int)GameStates.SettingsMenu;
                    SceneManager.LoadScene((int)GameStates.PlayerSelectionState, LoadSceneMode.Single);
                    break;
                }

            case GameStates.TutorialState:
                {
                    isPaused = false;
                    //FillOrignalScoreValues();
                    currentState = (int)GameStates.TutorialState;
                    SceneManager.LoadScene((int)GameStates.TutorialState, LoadSceneMode.Single);
                    //StartCoroutine(wait()); //get ChickenController id, color
                    break;
                }
            case GameStates.SelectModeState:
                {
                    //if (FindObjectOfType<MenuMusic>() != null)
                    //{
                    //    FindObjectOfType<MenuMusic>().GetComponent<AudioSource>().enabled = true;//.gameObject.SetActive(true);
                    //}
                    GameBGSound[(int)GameBGMusic.ModesMusic].enabled = false;
                    GameBGSound[(int)GameBGMusic.MainMenuMusic].enabled = true;
                    playersScoreList = new Dictionary<int, float>(PlayerList.Count);

                    currentState = (int)GameStates.SelectModeState;
                    SceneManager.LoadScene((int)GameStates.SelectModeState, LoadSceneMode.Single);
                    //StartCoroutine(playSound());
                    break;
                }
            //case GameStates.MoodTutorial:
            //    {
            //        if (FindObjectOfType<MenuMusic>() != null)
            //        {
            //            FindObjectOfType<MenuMusic>().GetComponent<AudioSource>().enabled = false;//.gameObject.SetActive(false);
            //        }
            //        currentState = (int)GameStates.MoodTutorial;
            //        if (MoodsList.Count > 0)
            //        {
            //            moodsTuorial = (MoodsTutorial)MoodsList[0];
            //            //SceneManager.LoadScene((int)GameStates.WinnerState, LoadSceneMode.Single);
            //            switch (moodsTuorial)
            //            {
            //                case MoodsTutorial.FTCTutorial:
            //                    {
            //                        SceneManager.LoadScene(((int)GameMoods.feedTheChicksMood) - 1, LoadSceneMode.Single);
            //                        break;
            //                    }
            //                case MoodsTutorial.ObstacleRaceTutorial:
            //                    {
            //                        SceneManager.LoadScene(((int)GameMoods.RaceMood) - 1, LoadSceneMode.Single);
            //                        break;
            //                    }
            //                case MoodsTutorial.FryPanMoodTutorial:
            //                    {
            //                        SceneManager.LoadScene(((int)GameMoods.FryPanMood) - 1, LoadSceneMode.Single);
            //                        break;
            //                    }
            //            }
            //        }
            //        else
            //        {
            //            //SceneManager.LoadScene((int)GameStates.SelectModeState, LoadSceneMode.Single);
            //            gameStates = GameStates.SelectModeState;
            //            SwitchGame();
            //        }
            //        break;
            //    }
            case GameStates.GamePlayState:
                {
                    Debug.Log(currentState);
                    //currentState = (int)GameStates.GamePlayState;
                    isPaused = true;

                    //if (FindObjectOfType<MenuMusic>() != null)
                    //{
                    //    FindObjectOfType<MenuMusic>().GetComponent<AudioSource>().enabled = false;//.gameObject.SetActive(false);
                    //}

                    GameBGSound[(int)GameBGMusic.MainMenuMusic].enabled = false;
                    GameBGSound[(int)GameBGMusic.ModesMusic].enabled = true;

                    //currentState = (int)GameStates.GamePlayState;
                    if (MoodsList.Count > 0)
                    {
                        ////forfinalwinner
                      //  EndofAllRounds = false;

                        gameMoods = (GameMoods)MoodsList[0];
                        switch (gameMoods)
                        {
                            case GameMoods.feedTheChicksMood:
                                {
                                    //StartCoroutine( playModeSound());
                                    GameBGSound[(int)GameBGMusic.ModesMusic].Play(20000);
                                    FinalWinnerID = 0;
                                    SceneManager.LoadScene((int)GameMoods.feedTheChicksMood, LoadSceneMode.Single);
                                    MoodsList.RemoveAt(0);
                                    //StartCoroutine(wait());
                                    break;
                                }
                            case GameMoods.RaceMood:
                                {
                                    GameBGSound[(int)GameBGMusic.ModesMusic].Play(20000);
                                    FinalWinnerID = 0;
                                    SceneManager.LoadScene((int)GameMoods.RaceMood, LoadSceneMode.Single);
                                    MoodsList.RemoveAt(0);
                                    //StartCoroutine(wait());
                                    break;
                                }
                            case GameMoods.FryPanMood:
                                {
                                    GameBGSound[(int)GameBGMusic.ModesMusic].Play(20000);

                                    FinalWinnerID = 0;
                                    SceneManager.LoadScene((int)GameMoods.FryPanMood, LoadSceneMode.Single);
                                    MoodsList.RemoveAt(0);
                                    //StartCoroutine(wait());
                                    break;
                                }
                            case GameMoods.FallingBlocks:
                                {
                                    GameBGSound[(int)GameBGMusic.ModesMusic].Play(20000);

                                    FinalWinnerID = 0;
                                    SceneManager.LoadScene((int)GameMoods.FallingBlocks, LoadSceneMode.Single);
                                    MoodsList.RemoveAt(0);
                                    //StartCoroutine(wait());
                                    break;
                                }
                        }

                    }
                    else
                    {
                        //SceneManager.LoadScene((int)GameStates.SelectModeState, LoadSceneMode.Single);
                        /////final winner
                      //  EndofAllRounds = true;
                        gameStates = GameStates.SelectModeState;
                        SwitchGame();
                    }
                    break;
                }
            case GameStates.WinnerState:
                currentState = (int)GameStates.WinnerState;
                SceneManager.LoadScene((int)GameStates.WinnerState, LoadSceneMode.Single);

                break;

            case GameStates.Introduction:
                currentState = (int)GameStates.Introduction;
                SceneManager.LoadScene((int)GameStates.Introduction, LoadSceneMode.Single);

                break;
        }
    }

    //make id of player attached to the value he must take 
    //Score 25/5/2016
    public void ArrangePlayerAccourdingToScore(Dictionary<int, float> scoreList)
    {
        orderedScoreDic = scoreList.OrderByDescending(kv => kv.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        if (playersScoreList.Count <= 0)
        {
            foreach (var item in orderedScoreDic) { playersScoreList.Add(item.Key, 0); }
        }
    }
    //End

    public void SetScore(Dictionary<int, float> scoreList)
    {
        var orderedList = scoreList.OrderByDescending(kv => kv.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        //// Display results for test.
        //foreach (var pair in orderedList)
        //{
        //    Debug.Log(pair.Key + " -> " + pair.Value);
        //}
        ////End of Test

        if (playersScoreList.Count <= 0)
        {
            foreach (var item in orderedList) { playersScoreList.Add(item.Key, 0); }
        }
        int pkey;
        for (int i = 0; i < orderedList.Count; i++)
        {
            switch (i)
            {
                case 0:
                    pkey = orderedList.Keys.ElementAt(0);
                    playersScoreList[pkey] += 5;
                    break;
                case 1:
                    pkey = orderedList.Keys.ElementAt(1);
                    playersScoreList[pkey] += 3;
                    break;
                case 2:
                    pkey = orderedList.Keys.ElementAt(2);
                    playersScoreList[pkey] += 1;
                    break;
            }
        }
        //Test the Accumalted Values
        foreach (var item in playersScoreList)
        {
            Debug.Log(item.Key + " , " + item.Value);
        }
        //End Of Test
    }

    public Dictionary<int, float> GetScore()
    {
        return playersScoreList;
    }

    public void setWinner(int id, Color winner)
    {
        FinalWinnerID = id;
        int index = PlayerList.IndexOf(id);
        FinalWinnerColor = winner;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.1f);
        Debug.Log("wait");
        ChickenController[] ChickenControllerArray = GameObject.FindObjectsOfType<ChickenController>();// GetComponents<ChickenController>();
        ChickenControllerData data = new ChickenControllerData();
        for (int i = 0; i < ChickenControllerArray.Length; i++)
        {
            data = new ChickenControllerData();
            data.ChickenColor = ChickenControllerArray[i].chickColor;
            // data.ChickenColor = new Color(data.ChickenColor.r, data.ChickenColor.g, data.ChickenColor.b,1);
            data.ChickedId = ChickenControllerArray[i].id;
            ChickenControllerDataList.Add(data);
            //Debug.Log(item.id + "->" + item.chickColor);
        }
    }

    IEnumerator playModeSound()
    {
        yield return new WaitForSeconds(.1f);
        //Debug.Log("playsound");
        GameBGSound[(int)GameBGMusic.MainMenuMusic].Play();
        yield return null;
    }

    public void Update_Sound()
    {
        AudioListener.volume = Sfx_Sound / 100.0f;
        Music_AudioSorce.GetComponent<AudioSource>().volume = Bg_Sound / 100.0f;
    }
    public void Set_Bg_Sound_Volum(int value)
    {
        Bg_Sound = value;
        Update_Sound();
    }
    public void Set_Sfx_Sound_Volum(int value)
    {
        Sfx_Sound = value;
        Update_Sound();
    }
}
