using UnityEngine;
using System.Collections;

public class SlowingTile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.layer == 9 || collision2D.gameObject.layer == 13 || collision2D.gameObject.layer == 14)
        {
            collision2D.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-28, 0, 0);
        }

    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.layer == 9 || collision2D.gameObject.layer == 13 || collision2D.gameObject.layer == 14)
        {
            collision2D.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(7, 0, 0);
        }

    }

}
