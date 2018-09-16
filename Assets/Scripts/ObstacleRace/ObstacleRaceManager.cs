using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObstacleRaceManager : MonoBehaviour
{

    public static ObstacleRaceManager Current;

    public Transform startOfRace;
    public Transform endOfRace;
    public float cameraOffset = 0.5f;

    Camera mainCamera;
    CameraMovement cameraMovmentScript;

    //----------------------------------------

    //3ack just 3lshan el donya t3dy
    public GameObject winnerCanvas;


    public AudioSource BG;
    public float loseTime = 2f; //time between every lose
    public float amountOfLoose = 10f;//amount of loaseing energy

    public float timerSpeed = 0.2f;
    public float timerLooseAmount = 0.2f;
    public float timerIncreaseAmount = 0.2f;

    //public GameObject objTimer;
    public Canvas UICanvas;
    //public Slider timerSlider;
    // ModeTimer timer;

    //public float marginOffset;

    //GenerateCramb crumbObj = new GenerateCramb();
    List<Healthbar> playersHealth;
    public List<GameObject> players;


    //public Text labelWinner;
    [HideInInspector]
    public GameObject winner;

    Animator CameraAnimator;
    List<Animator> PlayersAnimators;
    //3ack
    List<ChickenController> playerController;

    //puplic till test
    Dictionary<int, float> playersScore;

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
        cameraMovmentScript = Camera.main.GetComponent<CameraMovement>();

        //Application.DontDestroyOnLoad(this);
        // timer = timerSlider.GetComponent<ModeTimer>();
        playersHealth = new List<Healthbar>(players.Count);
        PlayersAnimators = new List<Animator>(players.Count);
        playerController = new List<ChickenController>(players.Count);

        players = PlayersManager.current.EnablePlayers(); //get players from playersManager
        playersScore = new Dictionary<int, float>(players.Count);

        for (int i = 0; i < players.Count; i++)
        {
            playersHealth.Add(players[i].GetComponent<Healthbar>());
            PlayersAnimators.Add(players[i].GetComponent<Animator>());
            playerController.Add(players[i].GetComponent<ChickenController>());

            //for Set score of each player
            playersScore.Add(playerController[i].id, 0);
        }

        CameraAnimator = Camera.main.GetComponent<Animator>();
    }
    void Start()
    {
        // labelWinner.text = string.Empty;

        // playersHealth[0].gameObject.GetComponent<ChickenController>().OnDeath += ObstacleRaceManager_OnDeath;
        StartCoroutine(LoseEnergy());
        //   StartCoroutine(LoseTime());
    }

    // Update is called once per frame
    //void Update()
    //{
    //    cameraMovmentScript.SetCameraSize(GetFastestPlayer(), GetSlowestPlayer());
    //    cameraMovmentScript.SetCamera(GetFastestPlayer());
    //}
    void LateUpdate()
    {
        // CameraFollow(GetFastestPlayer());
        //esmat
          cameraMovmentScript.SetCameraSize(GetFastestPlayer(), GetSlowestPlayer());

        cameraMovmentScript.SetCamera(GetFastestPlayer());
        //cameraMovmentScript.SetCamera(GetSlowestPlayer());
    }

    Transform GetFastestPlayer()
    {
        Transform fastest = null;
        float distance = float.MaxValue;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null)
            {
                if (endOfRace.position.x - players[i].transform.position.x < distance)
                {
                    distance = endOfRace.position.x - players[i].transform.position.x;
                    fastest = players[i].transform;
                }
            }
        }
        //Debug.Log(fastest.name);
        return fastest;
    }


    Transform GetSlowestPlayer()
    {
        Transform slowest = null;
        float distance = float.MinValue;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null)
            {
                if (endOfRace.position.x - players[i].transform.position.x > distance)
                {
                    distance = endOfRace.position.x - players[i].transform.position.x;
                    slowest = players[i].transform;
                }
            }
        }
        //Debug.Log(fastest.name);
        return slowest;
    }


    IEnumerator LoseEnergy()
    {
        while (players.Count > 0)
        {
            if (!playersList.current.isPaused)
            {

                //update score of eack player accourding to time he lives 
                UpdateScore(0.1f, false);

                Debug.Log(players.Count);
                for (int i = 0; i < players.Count; i++)
                {
                    if (playersHealth[i].Damage(amountOfLoose)) //.currentHealth -= amountOfLoose;
                    {
                        //if (PlayersAnimators[i] != null)
                        //{
                        //set Score
                        playersScore[playerController[i].id] += playerController[i].transform.position.x - startOfRace.position.x;

                        playerController[i].PlayerDeath();
                        //Debug.Log(PlayersAnimators[i].GetComponent<ChickenController>().chickColor);
                        //PlayersAnimators[i].SetTrigger("Death");

                        //CameraAnimator.SetTrigger("isDead");
                        ////Destroy(players[i].gameObject);



                        players.RemoveAt(i);
                        playersHealth.RemoveAt(i);
                        PlayersAnimators.RemoveAt(i);
                        playerController.RemoveAt(i);
                        // }
                        CheckEndOfMode();
                    }
                }
            }
            yield return new WaitForSeconds(loseTime);
        }
    }


    void CheckEndOfMode()
    {
        if (players.Count < 1)
        {
            EndOfMode();
        }
    }

    public void EndOfMode()
    {
        playersList.current.FinalWinnerColor = Color.white;
        GameObject temp = FindTheWinner();

        //3ack
        if (temp)
        {
            ChickenController TempController = temp.GetComponent<ChickenController>();
            playersList.current.setWinner(TempController.id, TempController.chickColor);
        }

        UpdateScore(0, true);
        //playersList.current.SetScore(playersScore);
        playersList.current.ArrangePlayerAccourdingToScore(playersScore);

        //playersList.current.gameStates = GameStates.InnerWinner;
        playersList.current.gameStates = GameStates.WinnerState;
        playersList.current.SwitchGame();

        //StopAllCoroutines();
        //Time.timeScale = 0;

        //SceneManager.LoadScene(2);
        //winnerCanvas.SetActive(true);
        //Debug.Log("hello");
    }

    void UpdateScore(float value, bool atEndOfMood = false)
    {
        for (int i = 0; i < playerController.Count; i++)
        {
            if (atEndOfMood)
            {
                playersScore[playerController[i].id] += playerController[i].transform.position.x - startOfRace.position.x;
                Debug.Log(playerController[i].transform.position.x - startOfRace.position.x);
            }
            else
                playersScore[playerController[i].id] += value;
        }
    }

    GameObject FindTheWinner()
    {
        return winner;
    }

}





