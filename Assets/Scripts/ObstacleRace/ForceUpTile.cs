using UnityEngine;
using System.Collections;

public class ForceUpTile : MonoBehaviour {

    public float xForce = 10000;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // anim.SetTrigger("start");
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.layer == 9 || collision2D.gameObject.layer == 13 || collision2D.gameObject.layer == 14)
        {
            anim.SetTrigger("start");

            collision2D.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, xForce), ForceMode2D.Force);
        }
    }
}
