
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{

    public AudioSource BG;
    //public static FTCManager Current;
    public float loseTime = 2f; //time between every lose
    public float amountOfLoose = 10f;//amount of loaseing energy

    List<Healthbar> playersHealth;
    public List<GameObject> players;
    List<int> playerList;

    // Use this for initialization
    void Awake()
    {
        BG.Play();
        
        if (PlayersManager.current)
        {
            players = PlayersManager.current.EnablePlayers();
        }
        playersHealth = new List<Healthbar>(players.Count);
        for (int i = 0; i < players.Count; i++)
        {
            playersHealth.Add(players[i].GetComponent<Healthbar>());
            // PlayersAnimators.Add(players[i].GetComponent<Animator>());
            //3ack
            //playerController.Add(players[i].GetComponent<ChickenController>());
        }
    }
    void Start()
    {
        StartCoroutine(LoseEnergy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoseEnergy()
    {
        while (true)
        {
            for (int i = 0; i < playersHealth.Count; i++)
            {
                playersHealth[i].Damage(amountOfLoose);
            }
            yield return new WaitForSeconds(loseTime);
        }
    }

}



