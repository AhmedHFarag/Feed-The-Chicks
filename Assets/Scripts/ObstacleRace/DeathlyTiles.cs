using UnityEngine;
using System.Collections;

public class DeathlyTiles : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.layer == 9 || collision2D.gameObject.layer == 13 )

        collision2D.gameObject.GetComponent<ChickenController>().PlayerDeath();
    }
}
