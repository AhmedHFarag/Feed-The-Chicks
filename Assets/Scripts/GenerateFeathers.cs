using UnityEngine;
using System.Collections;

public class GenerateFeathers : MonoBehaviour
{

    //public static GenerateFeathers current;
    GameObject feather;
    [HideInInspector]
    public Transform fParent;

    // Use this for initialization
    void Start()
    {
        //current = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ProduceFeathers()
    {

        feather = GenerateObject.current.GetPooledObj();
        if (feather)
        {
            //shellRigidbody = shell.GetComponent<Rigidbody>();
            feather.transform.parent = fParent.transform;

            //feather.transform.position = new Vector3(Random.Range(Left.position.x, Right.position.x), Left.position.y, 0);

            feather.SetActive(true);
            //feather.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, 10), Random.Range(0, -20)), ForceMode2D.Impulse);
        }
    }
}
