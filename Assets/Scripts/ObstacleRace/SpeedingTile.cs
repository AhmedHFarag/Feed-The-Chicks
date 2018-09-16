using UnityEngine;
using System.Collections;

public class SpeedingTile : MonoBehaviour {
   // public float xForce = 10000;
	void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
      
	}
    //void OnCollisionEnter2D(Collision2D collision2D)
    //{
    //    Debug.Log("Entered");
    //    collision2D.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce, 0), ForceMode2D.Force);
    //}

    void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.layer == 9 || collision2D.gameObject.layer == 13 || collision2D.gameObject.layer == 14)
       {
           collision2D.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(28, collision2D.gameObject.GetComponent<Rigidbody2D>().velocity.y, 0);
       }
       
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.layer == 9 || collision2D.gameObject.layer == 13 || collision2D.gameObject.layer == 14)
        {
            collision2D.gameObject.GetComponent<Rigidbody2D>().velocity=new Vector3(7,0,0);
        }

    }

}
