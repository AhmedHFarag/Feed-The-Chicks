using UnityEngine;
using System;

public class TipsNext : MonoBehaviour {

    public InputManagerScript inputManager;
    public GameObject tipsPanel;
    public GameObject readyStedyGoObj;
    // Use this for initialization
    void Start () {
        inputManager.P1_START_Initiated += this.StartGame;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void StartGame(object sender, EventArgs e)
    {
       // gameObject.SetActive(false);
        tipsPanel.SetActive(false);
        readyStedyGoObj.SetActive(true);
        //readyStedyGoObj.GetComponent<Animator>().enabled = true;
       // playersList.current.isPaused = false;
    }
}
