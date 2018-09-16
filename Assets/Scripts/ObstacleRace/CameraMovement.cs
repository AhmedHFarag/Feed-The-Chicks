using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float zoomSpeed = 1;
    public float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 5.4f;
    public float maxOrtho = 9.0f;


    Vector3 velocity;
    Vector3 vary;
    Animator camerazoom;
    void Awake()
    {
        camerazoom = GetComponent<Animator>();
        targetOrtho = Camera.main.orthographicSize;
    }
    public void SetCamera(Transform objectToFollow)
    {
        //esmat
        if(objectToFollow!=null)
       this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(objectToFollow.position.x, 0.45f, this.transform.position.z), ref velocity, Time.deltaTime);
  
        //   this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(objectToFollow.position.x, objectToFollow.transform.position.y+2, this.transform.position.z), ref velocity, Time.deltaTime);
        //this.transform.position = Vector3.LerpUnclamped(new Vector3(this.transform.position.x, 0, this.transform.position.z), new Vector3(objectToFollow.position.x, 0, objectToFollow.position.z), Time.deltaTime);
        //this.transform.position = new Vector3(objectToFollow.transform.position.x,0, 0);
        //this.transform.position.y = 0;
    }
    float i = 0;
    bool direction;
    public void SetCameraSize(Transform p1, Transform p2)
    {
        float distance = Vector3.Distance(p1.position, p2.position);
        //   camerazoom.SetFloat("distance", distance);
        if (distance > 10)
        {
            if (!direction)
            {
                direction = true;
                i = 0;
            }
            i++;
            Debug.Log("yathreb");
            Camera.main.orthographicSize = Mathf.Lerp(5.4f, 9f, i * Time.deltaTime);

        }
        else
        {
            if (direction)
            {
                Debug.Log("hi");
                direction = false;
                i = 0;
            }
            Camera.main.orthographicSize = Mathf.Lerp(9f, 5.4f, i * Time.deltaTime);
            i++;
        }
    }

    public void StopZooming()
    {
        camerazoom.enabled=false;
    }
}
