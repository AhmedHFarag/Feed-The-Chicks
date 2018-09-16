using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreValueFading : MonoBehaviour
{
    float alpha;
    Text scoretxt;
    // Use this for initialization
    void Start()
    {
        scoretxt = GetComponent<Text>();
        alpha = scoretxt.color.a;
    }

    // Update is called once per frame
    void Update()
    {
       //// alpha -= 0.1f * Time.deltaTime;
       // alpha = (alpha - 0.1f * Time.deltaTime > 0) ? alpha - 0.1f * Time.deltaTime : 0;
       // scoretxt.color = new Color(scoretxt.color.r, scoretxt.color.g, scoretxt.color.b, alpha);
    }

    void Fading()
    {
        while (alpha > 0)
        {
            alpha = (alpha - 0.1f * Time.deltaTime > 0) ? alpha - 0.1f * Time.deltaTime : 0;
            scoretxt.color = new Color(scoretxt.color.r, scoretxt.color.g, scoretxt.color.b, alpha);
        }
    }
}
