﻿using UnityEngine;
using System.Collections;

public class RotatingWheel : MonoBehaviour {
     Transform wheel;
     public float rotationSpeed;
	// Use this for initialization
	void Start () {
      //  rotationSpeed = 0.5f;
        wheel = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
  //      wheel.RotateAround(new Vector3(0, 0, 1), 20);
        wheel.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed);
	}
}
