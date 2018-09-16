using UnityEngine;
using System.Collections;

public class GoBack : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnClick()
    {
        playersList.current.gameStates = GameStates.PlayerSelectionState;
        playersList.current.SwitchGame();
    }
}
