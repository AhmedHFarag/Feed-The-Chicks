using UnityEngine;
using System.Collections;

public class Roaster : MonoBehaviour {
    Transform roaster;
    public float rotationSpeed;
    // Use this for initialization
    void Start()
    {
        //  rotationSpeed = 0.5f;
        roaster = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //      wheel.RotateAround(new Vector3(0, 0, 1), 20);
        roaster.transform.Rotate(new Vector3(0, 1, 0), rotationSpeed);
    }
}
