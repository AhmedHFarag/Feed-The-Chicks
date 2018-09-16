using UnityEngine;
using System.Collections;

public class GenerateCramb : MonoBehaviour
{
    public Transform Left;
    //public float borderOffset = 0;
    public float timeForGenerateCrumbs = 5;
    public int MaxCrambsNumber;

    float crumbRange;
    GameObject cramb;
    Vector3 startPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        crumbRange = Camera.main.orthographicSize * Screen.width / Screen.height;
        StartCoroutine(GenerateCrambs());
    }
    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator GenerateCrambs()
    {
        while (true)
        {
            if (!playersList.current.isPaused)
            {
                int noOfCrumbs = Random.Range(1, MaxCrambsNumber);
                for (int i = 0; i <= noOfCrumbs; i++)
                {
                    cramb = GenerateObject.current.GetPooledObj();
                    if (cramb)
                    {
                        //shellRigidbody = shell.GetComponent<Rigidbody>();
                        //cramb.transform.parent = this.transform;
                        //cramb.transform.position = new Vector3(Random.Range(Left.position.x, Right.position.x), Left.position.y, 0);
                        cramb.transform.position = new Vector3(
                            Camera.main.transform.position.x + Random.Range(-crumbRange,
                            crumbRange
                            ),
                            Left.position.y,
                            0);

                        cramb.SetActive(true);
                        cramb.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, 10), Random.Range(0, -9)), ForceMode2D.Impulse);
                    }
                }
            }
            yield return new WaitForSeconds(timeForGenerateCrumbs);
        }
    }
    float GetScerenWidth()
    {
        return Camera.main.orthographicSize;
    }
    //public void GenerateCrumbs()
    // {
    //     int noOfCrumbs = Random.Range(1, MaxCrambsNumber);
    //     for (int i = 0; i <= noOfCrumbs; i++)
    //     {
    //         cramb = GenerateObject.current.GetPooledObj();
    //         if (cramb)
    //         {
    //             //shellRigidbody = shell.GetComponent<Rigidbody>();
    //             cramb.transform.parent = this.transform;
    //             cramb.transform.position = new Vector3(Random.Range(Left.position.x, Right.position.x), Left.position.y, 0);

    //             cramb.SetActive(true);
    //             cramb.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, 10), Random.Range(0, -20)), ForceMode2D.Impulse);
    //         }
    //     }
    // }
}
