using UnityEngine;
using System.Collections;

public class GoBackToGamePlay : MonoBehaviour
{
    public float waitForDuration = .3f; // time needed to wait after it change scene in seconds

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ChangeState());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(waitForDuration);
        Debug.Log("Call Courtine");
        //playersList.current.gameStates = GameStates.MoodTutorial;
        playersList.current.gameStates = GameStates.GamePlayState;
        playersList.current.SwitchGame();
    }
}
