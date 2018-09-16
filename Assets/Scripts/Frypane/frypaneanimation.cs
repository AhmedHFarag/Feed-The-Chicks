using UnityEngine;
using System.Collections;

public class frypaneanimation : MonoBehaviour
{
  
    public float AnimationDuration = 8;
    Animator fryAnim;
	// Use this for initialization
    void Awake()
    {
        fryAnim = GetComponent<Animator>();
    }
	void Start () {

       
        StartCoroutine(FryPaneAnimation());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator FryPaneAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(AnimationDuration);
            fryAnim.Play("pan");
            StartCoroutine(StopFry());
        }
        
    }
    IEnumerator StopFry() {
        yield return new WaitForSeconds(4);
        fryAnim.Play("idle");

    }
}
