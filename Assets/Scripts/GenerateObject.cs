using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateObject : MonoBehaviour
{
    public static GenerateObject current;
    public GameObject pooledObjectOrignalCrumb;
    public GameObject pooledObjectSpecialCrumb;
    public int pooledAmountCrumb = 5;
    public bool willGrow = false;

    List<GameObject> CrumbsList;

    void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start()
    {
        CrumbsList = new List<GameObject>();
        GameObject obj;
        int random = Random.Range(2, pooledAmountCrumb);
        //random = 1;
        for (int i = 0; i < pooledAmountCrumb; i++)
        {
            //random = Random.Range(0, 3);
            //if (random == 0)
            //{
            //    random = 1;
            //}
            //else
            //{
            //    random = Random.Range(1, 3);
            //}
            //if (random == 1)
            //{
            //    obj = Instantiate(pooledObjectOrignalCrumb);
            //}
            //else
            //{
            //    obj = Instantiate(pooledObjectSpecialCrumb);
            //}

            if (i == random)
            {
                obj = Instantiate(pooledObjectSpecialCrumb);
            }
            else
            {
                obj = Instantiate(pooledObjectOrignalCrumb);
            }
            obj.SetActive(false);
            CrumbsList.Add(obj);
        }
    }

    public GameObject GetPooledObj()
    {
        for (int i = 0; i < CrumbsList.Count; i++)
        {
            if (!CrumbsList[i].activeInHierarchy)
            {
                //pooledObjectOrignalCrumbs[i].SetActive(true);
                return CrumbsList[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(pooledObjectOrignalCrumb);
            CrumbsList.Add(pooledObjectOrignalCrumb);
            return obj;
        }
        return null;
    }
}
