using UnityEngine;
using System.Collections;

public class frypane : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    float AnimationCoolDown = 8;

    public float xForce;
    public float yForce;
    public Vector2 Force;
    public GameObject Forcess;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Fry());
        xForce = (Random.Range(-1000.0F, 1000.0f));
        yForce = (Random.Range(-400.0f, 40.0f));
        Force.x = 0;
        Force.y = 2;
    }
    IEnumerator returnto()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("inactive");
        Forcess.gameObject.SetActive(false);
        Force.y = 2;
        Force.x = 0;
    }

    IEnumerator Fry()
    {
        while (true)
        {
            if (!playersList.current.isPaused)
            {            
                anim.Play("pan");
                Forcess.gameObject.SetActive(true);
                Force.x = 9;
                Force.y = 9;
                StartCoroutine(returnto());
            }
            yield return new WaitForSeconds(AnimationCoolDown);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Animator panAnim = gameObject.GetComponent<Animator>();
        if (!playersList.current.isPaused && panAnim.enabled == false)
        {
            panAnim.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if ((collision2D.gameObject.layer == 9 || collision2D.gameObject.layer == 13 || collision2D.gameObject.layer == 14) && !playersList.current.isPaused)
        {


            // collision2D.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce, yForce), ForceMode2D.Force);
            // collision2D.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, 10), Random.Range(9, 9)), ForceMode2D.Impulse);
            // collision2D.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,2), ForceMode2D.Impulse);
            collision2D.gameObject.GetComponent<Rigidbody2D>().AddForce(Force, ForceMode2D.Impulse);
        }
    }
}
