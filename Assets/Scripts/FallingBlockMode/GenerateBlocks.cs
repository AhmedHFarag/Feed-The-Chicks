using UnityEngine;
using System.Collections;

public class GenerateBlocks : MonoBehaviour
{
    public Transform Left;
    //public float borderOffset = 0;
    public float timeForblocksRange = 5;
    public int MaxBlockNumber;

    float blocksRange;
    GameObject block;
    Vector3 startPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        blocksRange = Camera.main.orthographicSize * Screen.width / Screen.height;
        StartCoroutine(Generateblocks());
    }
    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Generateblocks()
    {
        while (true)
        {
            if (!playersList.current.isPaused)
            {
                int noOfCrumbs = Random.Range(1, MaxBlockNumber);
                for (int i = 0; i <= noOfCrumbs; i++)
                {
                    block = GenerateBlocksObject.current.GetPooledObj();
                    if (block)
                    {
                        //shellRigidbody = shell.GetComponent<Rigidbody>();
                        //block.transform.parent = this.transform;
                        //block.transform.position = new Vector3(Random.Range(Left.position.x, Right.position.x), Left.position.y, 0);
                        block.transform.position = new Vector3(
                            Camera.main.transform.position.x + Random.Range(-blocksRange,
                            blocksRange
                            ),
                            Left.position.y,
                            0);

                        block.SetActive(true);
                        block.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0, 0), Random.Range(0, -9)), ForceMode2D.Impulse);
                    }
                }
            }
            yield return new WaitForSeconds(timeForblocksRange);
        }
    }
    float GetScerenWidth()
    {
        return Camera.main.orthographicSize;
    }
    //public void GenerateCrumbs()
    // {
    //     int noOfCrumbs = Random.Range(1, MaxBlockNumber);
    //     for (int i = 0; i <= noOfCrumbs; i++)
    //     {
    //         block = GenerateObject.current.GetPooledObj();
    //         if (block)
    //         {
    //             //shellRigidbody = shell.GetComponent<Rigidbody>();
    //             block.transform.parent = this.transform;
    //             block.transform.position = new Vector3(Random.Range(Left.position.x, Right.position.x), Left.position.y, 0);

    //             block.SetActive(true);
    //             block.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, 10), Random.Range(0, -20)), ForceMode2D.Impulse);
    //         }
    //     }
    // }


}
