using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class FTCManager : MonoBehaviour
{
    //just 3lshan el donya t3dy
    public GameObject winnerCanvas;


    public AudioSource BG;
    public static FTCManager Current;
    public float loseTime = 2f; //time between every lose
    public float amountOfLoose = 10f;//amount of loaseing energy

    public float timerSpeed = 0.2f;
    public float timerLooseAmount = 0.2f;
    public float timerIncreaseAmount = 0.2f;

    //public GameObject objTimer;
    public Canvas UICanvas;
    public Slider timerSlider;
    ModeTimer timer;

    public float marginOffset;

    //GenerateCramb crumbObj = new GenerateCramb();
    List<Healthbar> playersHealth;
    //List<float> FinalplayersHealth;
    public List<GameObject> players;

    Dictionary<int, float> playersScore;


    //List<int> playerList;

    //public Text labelWinner;
    [HideInInspector]
    public GameObject winner;

    Animator CameraAnimator;
    List<Animator> PlayersAnimators;

    //3ack
    List<ChickenController> playerController;

    void Awake()
    {
        BG.Play();
        //Time.timeScale = 1;
        //Start()
        if (Current == null)
        {
            //DontDestroyOnLoad(gameObject);
            Current = this;
        }

        //Application.DontDestroyOnLoad(this);
        timer = timerSlider.GetComponent<ModeTimer>();

        playersHealth = new List<Healthbar>(players.Count);
        PlayersAnimators = new List<Animator>(players.Count);
        //3ack
        playerController = new List<ChickenController>(players.Count);
        //FinalplayersHealth = new List<float>(players.Count);

        players = PlayersManager.current.EnablePlayers();
        playersScore = new Dictionary<int, float>(players.Count);

        for (int i = 0; i < players.Count; i++)
        {
            playersHealth.Add(players[i].GetComponent<Healthbar>());
            PlayersAnimators.Add(players[i].GetComponent<Animator>());
            //3ack
            playerController.Add(players[i].GetComponent<ChickenController>());

            //for Set score of each player
            playersScore.Add(playerController[i].id, 0);

            //3ack
            //Debug.Log(players[i] + "->" + FindObjectOfType<playersList>().PlayerList[i]);
            //players[i].GetComponent<ChickenController>().id = FindObjectOfType<playersList>().PlayerList[i];
        }

        CameraAnimator = Camera.main.GetComponent<Animator>();

        //for (int i = 0; i < NewGameManager.current.EnablePlayers().Count; i++)
        //{
        //    players.Add(GameObject.Instantiate(NewGameManager.current.EnablePlayers()[i]));
        //    players[i].SetActive(true);
        //}
    }
    // Use this for initialization
    void Start()
    {
        //labelWinner.text = string.Empty;

        // playersHealth[0].gameObject.GetComponent<ChickenController>().OnDeath += FTCManager_OnDeath;
        StartCoroutine(LoseEnergy());
        StartCoroutine(LoseTime());
    }

    //private void FTCManager_OnDeath()
    //{
    // //
    //}

    IEnumerator LoseEnergy()
    {
        while (true)
        {
            if (!playersList.current.isPaused)
            {
                //update score of eack player accourding to time he lives 
                UpdateScore(0.1f, false);

                for (int i = 0; i < playersHealth.Count; i++)
                {
                    if (playersHealth[i].Damage(amountOfLoose)) //.currentHealth -= amountOfLoose;
                    {
                        playerController[i].PlayerDeath();
                        //PlayersAnimators[i].SetTrigger("Death");
                        //CameraAnimator.SetTrigger("isDead");
                        ////Destroy(players[i].gameObject);
                        players.RemoveAt(i);
                        playersHealth.RemoveAt(i);
                        PlayersAnimators.RemoveAt(i);
                        playerController.RemoveAt(i);
                        CheckEndOfMode();
                    }
                }
            }
            yield return new WaitForSeconds(loseTime);
        }
        //yield return startLoseEnergy();
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            if (!playersList.current.isPaused)
            {
                //Slider sTimer =  timer.transform.GetChild(0).GetComponentInChildren<Slider>();

                if (timer.TimerLoose(timerLooseAmount))
                {
                    EndOfMode();
                }
            }
            yield return new WaitForSeconds(timerSpeed);
        }
        //yield return startLoseTime();
    }

    //IEnumerator GenerateCrumbs()
    //{
    //    while (true)
    //    {
    //        crumbObj.GenerateCrumbs();
    //    }
    //}

    GameObject FindTheWinner()
    {
        float max = 0;
        //winner = new GameObject();
        for (int i = 0; i < playersHealth.Count; i++)
        {
            if (playersHealth[i].currentHealth > max)
            {
                max = playersHealth[i].currentHealth;
                winner = playersHealth[i].gameObject;
            }
            else if (i > 0 & playersHealth[i].currentHealth == max)
            {
                winner = null;
            }
        }
        return winner;
    }

    void CheckEndOfMode()
    {
        if (players.Count < 2)
        {
            EndOfMode();
        }
    }

    void EndOfMode()
    {
        UpdateScore(0, true);
        //playersList.current.SetScore(playersScore);
        playersList.current.ArrangePlayerAccourdingToScore(playersScore);

        //for test score
        //foreach (var item in playersScore)
        //{
        //    Debug.Log(item.Key);
        //    Debug.Log(item.Value);
        //}

        //var items = from pair in playersScore
        //            orderby pair.Value ascending
        //            select pair;

        playersList.current.FinalWinnerColor = Color.white;
        GameObject temp = FindTheWinner();

        //3ack
        if (temp)
        {
            ChickenController TempController = temp.GetComponent<ChickenController>();
            playersList.current.setWinner(TempController.id, TempController.chickColor);
        }

        //playersList.current.gameStates = GameStates.InnerWinner;
        playersList.current.gameStates = GameStates.WinnerState;
        playersList.current.SwitchGame();
        //StartCoroutine(GotoWinnerScreen());

    }

    void UpdateScore(float value, bool atEndOfMood = false)
    {
        for (int i = 0; i < playerController.Count; i++)
        {
            if (atEndOfMood)
                playersScore[playerController[i].id] += playerController[i].gameObject.GetComponent<Healthbar>().currentHealth;
            else
                playersScore[playerController[i].id] += value;
        }
    }
    IEnumerator GotoWinnerScreen()
    {
        //if (FindTheWinner() != null)
        //{
        //    //Camera.main.transform.position = FindTheWinner().transform.position;// + new Vector3(10, 10, 0);
        //}

        yield return new WaitForSeconds(.5f);
        playersList.current.SwitchGame();
    }
}
