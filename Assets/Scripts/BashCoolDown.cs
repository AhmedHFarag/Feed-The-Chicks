using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BashCoolDown : MonoBehaviour
{

    public Slider coolDownSlider;
    public float charageAmount;

    [HideInInspector]
    public bool isUsed = false;

    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Damage()
    {
        coolDownSlider.value = 0;
        isUsed = true;
        return isUsed;
    }

    public void Charge(float chargeValue)
    {
        coolDownSlider.value += chargeValue;
    }
   
}
