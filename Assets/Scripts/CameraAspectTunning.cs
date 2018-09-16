using UnityEngine;
using System.Collections;

public class CameraAspectTunning : MonoBehaviour {
    public float DesiredWidth=10;
	// Use this for initialization
	void Start () {
        float aspect = Screen.width * 1.0f / Screen.height;//-->4/3
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = (DesiredWidth / aspect) / 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
