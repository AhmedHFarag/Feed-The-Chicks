using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public GameObject pausePanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartModeGame()
    {
        pausePanel.SetActive(false);
        playersList.current.isPaused = false;

    }
}
