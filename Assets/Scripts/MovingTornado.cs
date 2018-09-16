using UnityEngine;
using System.Collections;

public class MovingTornado : MonoBehaviour
{

    //Transform Tornado;
    public float tornadoSpeed = -35;
    // Use this for initialization
    void Start()
    {
        //tornadoSpeed = -35f;
        // Tornado = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playersList.current.isPaused)
        {
            tornadoSpeed += 0.05f;
            //      wheel.RotateAround(new Vector3(0, 0, 1), 20);
            this.transform.position = new Vector3(tornadoSpeed, 0, 0);
        }
    }
}
