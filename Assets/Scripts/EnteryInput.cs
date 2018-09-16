using UnityEngine;
using System.Collections;

public class EnteryInput : MonoBehaviour
{
    string[] cNames;
    // Use this for initialization
    void Start()
    {
        cNames = Input.GetJoystickNames();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.GetJoystickNames().Length);
        // int i = 1;
        for (int i = 1; i <= 8; i++)
        {
            if (Mathf.Abs(Input.GetAxis("P" + i + "Hori")) > 0.2F)//|| Mathf.Abs(Input.GetAxis("P" + i + "veri")) > 0.2F
            {
                //Debug.Log(i);
                // Debug.Log(Input.GetJoystickNames()[i - 1]);
                //if ()
                //{

                //}
            }
        }
    }
}

