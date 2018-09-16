using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ModeTimer : MonoBehaviour
{
    // public  ModeTimer current;
    public Slider timer;
    public Image timerend;
    public AudioSource timeend;
    public Color TimerImageColor = new Color(1, 0, 0, 0.3f);
    private bool changeColor;

    void Start()
    {
        // timerend.color = TimerImageColor;

    }
    void Update()
    {
        if (!playersList.current.isPaused)
        {
            if (timer.value < 0.5f)
            {

                if (changeColor)
                {
                    // Debug.Log("timer ending");
                    timeend.Play();
                    timerend.color = TimerImageColor;

                }
                else
                {

                    timerend.color = Color.Lerp(timerend.color, Color.clear, 3 * Time.deltaTime);

                }
                changeColor = false;
            }
        }


    }
    public ModeTimer()
    {
        // GameObject.Instantiate(timer);
    }
    public bool TimerLoose(float amount)
    {
        //Debug.Log(timer.value);
        bool isFinished = false;
        timer.value -= amount;
        changeColor = true;

        if (timer.value <= 0)
        {
            isFinished = true;
        }
        return isFinished;
    }

    public void TimerIncreaseAmount(float amount)
    {
        timer.value = Mathf.Min(timer.value + amount, timer.maxValue);
    }
}
