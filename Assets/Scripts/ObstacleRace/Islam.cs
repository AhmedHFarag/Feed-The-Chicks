using UnityEngine;
using System.Collections;

public class Islam : MonoBehaviour {

    //public Transform endOfRace;
    //public float cameraOffset = 0.5f;
    //public GameObject GameWinner;
    //Camera mainCamera;
    //CameraMovement cameraMovmentScript;

    ////----------------------------------------

    ////3ack just 3lshan el donya t3dy
    //public GameObject winnerCanvas;


    //public AudioSource BG;
    //public float loseTime = 2f; //time between every lose
    //public float amountOfLoose = 10f;//amount of loaseing energy

    //public float timerSpeed = 0.2f;
    //public float timerLooseAmount = 0.2f;
    //public float timerIncreaseAmount = 0.2f;

    ////public GameObject objTimer;
    //public Canvas UICanvas;
    //public Slider timerSlider;
    //ModeTimer timer;

    ////public float marginOffset;

    ////GenerateCramb crumbObj = new GenerateCramb();
    //List<Healthbar> playersHealth;
    //public List<GameObject> players;


    ////public Text labelWinner;
    //[HideInInspector]
    //public GameObject winner;

    //public GameObject lastServived;

    //Animator CameraAnimator;
    //List<Animator> PlayersAnimators;
    ////3ack
    //List<ChickenController> playerController;

    //void Awake()
    //{
    //    BG.Play();
    //    //Time.timeScale = 1;
    //    //Start()
    //    if (Current == null)
    //    {
    //        //DontDestroyOnLoad(gameObject);
    //        Current = this;
    //    }
    //    cameraMovmentScript = Camera.main.GetComponent<CameraMovement>();

    //    //Application.DontDestroyOnLoad(this);
    //    timer = timerSlider.GetComponent<ModeTimer>();
    //    playersHealth = new List<Healthbar>(players.Count);
    //    PlayersAnimators = new List<Animator>(players.Count);
    //    playerController = new List<ChickenController>(players.Count);


    //    players = PlayersManager.current.EnablePlayers(); //get players from playersManager
    //    for (int i = 0; i < players.Count; i++)
    //    {
    //        playersHealth.Add(players[i].GetComponent<Healthbar>());
    //        PlayersAnimators.Add(players[i].GetComponent<Animator>());
    //        playerController.Add(players[i].GetComponent<ChickenController>());
    //    }

    //    CameraAnimator = Camera.main.GetComponent<Animator>();
    //}
    //void Start()
    //{
    //    // labelWinner.text = string.Empty;

    //    // playersHealth[0].gameObject.GetComponent<ChickenController>().OnDeath += ObstacleRaceManager_OnDeath;
    //    StartCoroutine(LoseEnergy());
    //    StartCoroutine(LoseTime());
    //}

    //// Update is called once per frame
    //void LateUpdate()
    //{
    //    // CameraFollow(GetFastestPlayer());
    //    cameraMovmentScript.SetCamera(GetFastestPlayer());
    //}

    //Transform GetFastestPlayer()
    //{
    //    Transform fastest = null;
    //    float distance = float.MaxValue;
    //    for (int i = 0; i < players.Count; i++)
    //    {
    //        if (players[i] != null)
    //        {
    //            if (endOfRace.position.x - players[i].transform.position.x < distance)
    //            {
    //                distance = endOfRace.position.x - players[i].transform.position.x;
    //                fastest = players[i].transform;
    //            }
    //        }
    //    }
    //    //Debug.Log(fastest.name);
    //    return fastest;
    //}

    //IEnumerator LoseEnergy()
    //{
    //    while (true)
    //    {
    //        for (int i = 0; i < playersHealth.Count; i++)
    //        {
    //            if (playersHealth[i].Damage(amountOfLoose)) //.currentHealth -= amountOfLoose;
    //            {
    //                //lastServived = players[i];
    //                GameWinner.GetComponent<GameWinner>().PColor = players[i].GetComponent<ChickenController>().chickColor;
    //                GameWinner.GetComponent<GameWinner>().id = players[i].GetComponent<ChickenController>().id;
    //                PlayersAnimators[i].SetTrigger("Death");
    //                CameraAnimator.SetTrigger("isDead");
    //                //Destroy(players[i].gameObject);
    //                players.RemoveAt(i);
    //                playersHealth.RemoveAt(i);
    //                PlayersAnimators.RemoveAt(i);
    //                playerController.RemoveAt(i);


    //                //CheckEndOfMode();
    //            }
    //        }

    //        yield return new WaitForSeconds(loseTime);
    //    }
    //}

    //IEnumerator LoseTime()
    //{
    //    while (true)
    //    {
    //        //Slider sTimer =  timer.transform.GetChild(0).GetComponentInChildren<Slider>();
    //        if (timer.TimerLoose(timerLooseAmount))
    //        {
    //            EndOfMode();
    //        }
    //        yield return new WaitForSeconds(timerSpeed);
    //    }
    //}

    //void CheckEndOfMode()
    //{
    //    if (players.Count < 2)
    //    {
    //        EndOfMode();
    //    }
    //}

    //void EndOfMode()
    //{
    //    // GameObject temp =
    //    FindTheWinner();

    //    //3ack

    //    // Debug.Log(temp);
    //    // ChickenController TempController = temp.GetComponent<ChickenController>();
    //    playersList.current.setWinner(GameWinner.GetComponent<GameWinner>().id, GameWinner.GetComponent<GameWinner>().PColor);

    //    //StopAllCoroutines();
    //    //Time.timeScale = 0;

    //    //SceneManager.LoadScene(2);
    //    // winnerCanvas.SetActive(true);
    //    playersList.current.gameStates = GameStates.GamePlayState;
    //    playersList.current.SwitchGame();
    //}
    //void FindTheWinner()
    //{
    //    //float max = 0;
    //    ////winner = new GameObject();
    //    //for (int i = 0; i < playersHealth.Count; i++)
    //    //{
    //    //    if (playersHealth[i].currentHealth > max)
    //    //    {
    //    //        max = playersHealth[i].currentHealth;
    //    //        winner = playersHealth[i].gameObject;
    //    //    }
    //    //    else if (i > 0 & playersHealth[i].currentHealth == max)
    //    //    {
    //    //        winner = null;
    //    //    }
    //    //}
    //    //return winner;

    //    if (players.Count > 0)
    //    {
    //        for (int i = 0; i < players.Count; i++)
    //        {
    //            float max = 0;
    //            if (playersHealth[i].currentHealth > max)
    //            {
    //                max = playersHealth[i].currentHealth;
    //                //winner = players[i].gameObject;
    //                GameWinner.GetComponent<GameWinner>().PColor = players[i].GetComponent<ChickenController>().chickColor;
    //            }
    //        }
    //    }
    //    else
    //    {

    //    }
    //}
}
