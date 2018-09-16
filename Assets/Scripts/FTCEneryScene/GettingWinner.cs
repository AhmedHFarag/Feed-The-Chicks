using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GettingWinner : MonoBehaviour
{
    //public Image Avatar;
    //Image AvatarImage;

    Color winner;
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Image>().color = Color.white;
        if (playersList.current.FinalWinnerColor != null)
        {
            winner = playersList.current.FinalWinnerColor;
            //gameObject.GetComponent<Image>().color = winner.GetComponent<ChickenController>().chickColor;
            gameObject.GetComponent<Image>().color = winner;
        }
    }
}
