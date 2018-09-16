using UnityEngine;
using System.Collections;

public class EnableAI : MonoBehaviour {

    public Rigidbody2D AIRigid;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void enableAI()
    {
        AIRigid.isKinematic = false;
    }
}
