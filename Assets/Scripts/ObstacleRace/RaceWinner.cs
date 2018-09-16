using UnityEngine;
using System.Collections;

public class RaceWinner : MonoBehaviour
{
    // public GameObject winnerCanvas;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D info)
    {
        if (info.gameObject.layer == 9 || info.gameObject.layer == 13)
        {
            //winnerCanvas.SetActive(true);
            ObstacleRaceManager.Current.winner = info.gameObject;
            ObstacleRaceManager.Current.EndOfMode();
        }
    }
}
