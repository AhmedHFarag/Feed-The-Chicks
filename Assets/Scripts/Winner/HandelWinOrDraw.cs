using UnityEngine;
using System.Collections;

public class HandelWinOrDraw : MonoBehaviour
{

    public GameObject WinCanvas;
    public GameObject DrawCanvas;


    // Use this for initialization
    void Awake()
    {
        Debug.Log(playersList.current.FinalWinnerID);
        if (playersList.current.FinalWinnerID != 0 /* || playersList.current.FinalWinnerColor != new Color(0, 0, 0, 0)*/)
        {
            Debug.Log("win");
            WinCanvas.SetActive(true);
            DrawCanvas.SetActive(false);
        }
        else
        {
            Debug.Log("draw");
            WinCanvas.SetActive(false);
            DrawCanvas.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
