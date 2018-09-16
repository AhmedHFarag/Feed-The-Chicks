using UnityEngine;
using System.Collections;

public class EndJump : MonoBehaviour {

    public delegate void EndJumpdele();
    public static event EndJumpdele OnEndJumb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D info)
    {
        if (OnEndJumb != null) { OnEndJumb(); }
    }
}
