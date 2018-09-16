using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class Score : MonoBehaviour
{
    //insted of just GameObject[], and getting component in childern, we can either make 3 [], for id, color and bar; or making class holding those 3 [], and accessing it here as we got in lec. :)
    [SerializeField]
    GameObject[] ScoreArr;
    [SerializeField]
    Image FinalWinner;
    [SerializeField]
    Text FinalScore;

    // Use this for initialization
    void Awake()
    {
        //CanvasParent
        //ScoreArr = new GameObject[4];
        //end
        SetControllerIDandColor();
        AdjustPlayerScore();

    }
    void Start()
    {
        AccumalteScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (playersList.current.EndofAllRounds)
            AdjustFinalWinner();
    }
    void SetControllerIDandColor()
    {
        for (int i = 0; i < playersList.current.ChickenControllerDataList.Count; i++)
        {
            ScoreArr[i].SetActive(true);
            //CanvasParent
            //ScoreArr[i] = Instantiate(templateScore);
            //Debug.Log(parentCanvas);
            //ScoreArr[i].GetComponent<RectTransform>().SetParent(this.transform);// = parentCanvas;
            //Debug.Log(ScoreArr[i].GetComponent<RectTransform>().parent);
            //ScoreArr[i].GetComponent<RectTransform>().localPosition = scorePos[i].localPosition;
            //Debug.Log(ScoreArr[i].GetComponent<RectTransform>().localPosition);
            //end

            // we can either make 3 [], for id, color and bar; or making class holding those 3 [], and accessing it here as we got in lec., sa7 keda ?! 
            ScoreArr[i].transform.GetChild(0).GetComponent<Text>().text = playersList.current.ChickenControllerDataList[i].ChickedId.ToString();
            //Debug.Log(ScoreArr[i].transform.GetChild(0).GetComponent<Text>().text + " ,Index: " + i);
            //ScoreArr[i].transform.GetChild(3).GetComponent<Text>().color =
            ScoreArr[i].transform.GetChild(1).GetComponent<Image>().color= playersList.current.ChickenControllerDataList[i].ChickenColor;

        }
    }
    void AdjustPlayerScore()
    {
        //momken hena n3mel corotene 3lshan t set el value 3ala mra7el
        foreach (var i in playersList.current.GetScore())
        //foreach (var i in playersList.current.playersScoreList)
        {
            for (int j = 0; j < playersList.current.GetScore().Count; j++)
            //for (int j = 0; j < playersList.current.playersScoreList.Count; j++)
            {
                //set max of scorebar according to no of moods in the round
                ScoreArr[j].transform.GetChild(2).GetComponent<Slider>().maxValue = playersList.current.TotelNoOfMoods * 5;
                //Debug.Log(ScoreArr[j].transform.GetChild(0).GetComponent<Text>().text + " ,Key: " + i.Key +" ,Index: "+j);
                if (int.Parse(ScoreArr[j].transform.GetChild(0).GetComponent<Text>().text) == i.Key)
                {
                    ScoreArr[j].transform.GetChild(2).GetComponent<Slider>().value = i.Value;
                    ScoreArr[j].transform.GetChild(3).GetComponent<Text>().text = i.Value.ToString();


                }
            }
        }
    }
    void AdjustFinalWinner()
    {

        Debug.Log("WinnerScore");
        FinalWinner.color = ScoreArr.Max().transform.GetChild(1).GetComponent<Image>().color;
        FinalScore.text = ScoreArr.Max().transform.GetChild(3).GetComponent<Text>().text;
    }

    void AccumalteScore()
    {
        int value = 5;
        foreach (var i in playersList.current.orderedScoreDic)
        {
            //playersList.current.orderedScoreDic bdal  ScoreArr 3lshan d 2 wel tanya 4 wana m7taga 2 bas
            for (int j = 0; j < playersList.current.orderedScoreDic.Count; j++)
            {
                if (int.Parse(ScoreArr[j].transform.GetChild(0).GetComponent<Text>().text) == i.Key)
                {
                    playersList.current.playersScoreList[i.Key] += value;
                    ScoreArr[j].transform.GetChild(5).GetComponent<Text>().text = "+" + value.ToString();

                    if (ScoreArr[j].transform.GetChild(5).GetComponent<Animator>() != null)
                        ScoreArr[j].transform.GetChild(5).GetComponent<Animator>().SetTrigger("start");

                    //ScoreArr[j].transform.GetChild(2).GetComponent<Slider>().value += value;
                    StartCoroutine(SliderScoreAnimation(ScoreArr[j].transform.GetChild(2).GetComponent<Slider>(), value));
                    StartCoroutine(TextScoreAnimation(ScoreArr[j].transform.GetChild(3).GetComponent<Text>(), value));

                    value = (value - 2 > 0) ? value -= 2 : 0;
                }
            }
        }
    }

    IEnumerator SliderScoreAnimation(Slider scoreSlider, float value)
    {
        float preScore = scoreSlider.value;
        //accScore.text = preScore.ToString();

        //Debug.Log("PreScore: "+preScore+" ,SliderValue: "+scoreSlider.value + " ,Value: "+ value +" ,accScore: "+ accScore.text);
        while (scoreSlider.value < value + preScore)
        {
            scoreSlider.value += .5f;
            //accScore.text = (float.Parse(accScore.text) + .5).ToString();
            yield return new WaitForSeconds(0.04f);
            //Debug.Log("PreScore: " + preScore + " ,SliderValue: " + scoreSlider.value + " ,Value: " + value + " ,accScore: " + accScore.text);
        }
        yield return null;
    }


    IEnumerator TextScoreAnimation(Text accScore, float value)
    {
        float preScore = float.Parse(accScore.text);
        //accScore.text = preScore.ToString();

        //Debug.Log("PreScore: "+preScore+" ,SliderValue: "+scoreSlider.value + " ,Value: "+ value +" ,accScore: "+ accScore.text);
        while (float.Parse(accScore.text) < value + preScore)
        {
            //scoreSlider.value += .5f;
            accScore.text = (float.Parse(accScore.text) + 1).ToString();
            yield return new WaitForSeconds(0.1f);
            //Debug.Log("PreScore: " + preScore + " ,SliderValue: " + scoreSlider.value + " ,Value: " + value + " ,accScore: " + accScore.text);
        }
        yield return null;
    }



}
