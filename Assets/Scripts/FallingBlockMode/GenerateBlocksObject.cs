using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateBlocksObject : MonoBehaviour
{
    public static GenerateBlocksObject current;
    public GameObject pooledObjectBlocks;
    public int pooledAmountBlocks = 5;
    public bool willGrow = false;

    List<GameObject> BlocksList;

    void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start()
    {
        BlocksList = new List<GameObject>();
        GameObject obj;
        int random = Random.Range(2, pooledAmountBlocks);
        //random = 1;
        for (int i = 0; i < pooledAmountBlocks; i++)
        {
            obj = Instantiate(pooledObjectBlocks);

            obj.SetActive(false);
            BlocksList.Add(obj);
        }
    }
    //void Update()
    //{
    //    for (int i = 0; i < BlocksList.Count; i++)
    //    {
    //        if (BlocksList[i].transform.position.y<-5f)
    //        {
    //            Destroy(BlocksList[i]);
    //        }
    //    }
    //}
    public GameObject GetPooledObj()
    {
        for (int i = 0; i < BlocksList.Count; i++)
        {
            if (!BlocksList[i].activeInHierarchy)
            {
                //pooledObjectOrignalCrumbs[i].SetActive(true);
                return BlocksList[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(pooledObjectBlocks);
            BlocksList.Add(pooledObjectBlocks);
            return obj;
        }
        return null;
    }
}
