using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {
    public GameObject objectToFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = objectToFollow.transform.position;//new Vector3(objectToFollow.transform.position.x,transform.position.y,0);

    }
}
