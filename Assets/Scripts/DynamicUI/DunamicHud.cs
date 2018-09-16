using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DunamicHud : MonoBehaviour
{

    [SerializeField]
    GameObject[] HudPosArr;

    void Awake()
    {
        Debug.Log("tutorial awake");
        SetHudControllerIDandColor();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetHudControllerIDandColor()
    {
        for (int i = 0; i < playersList.current.ChickenControllerDataList.Count; i++)
        {
            HudPosArr[i].SetActive(true);

            // we can either make 3 [], for id, color and bar; or making class holding those 3 [], and accessing it here as we got in lec., sa7 keda ?! 
            HudPosArr[i].transform.GetChild(0).GetComponent<Text>().text = playersList.current.ChickenControllerDataList[i].ChickedId.ToString();
            //Debug.Log(ScoreArr[i].transform.GetChild(0).GetComponent<Text>().text + " ,Index: " + i);
            HudPosArr[i].transform.GetChild(1).GetComponent<Image>().color = playersList.current.ChickenControllerDataList[i].ChickenColor;
        }
    }
}
