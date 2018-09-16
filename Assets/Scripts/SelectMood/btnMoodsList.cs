using UnityEngine;
using System.Collections;

public class btnMoodsList : MonoBehaviour {

    public RectTransform moodList;
    public RectTransform SelectedList;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if (transform.parent == moodList)
        {
            /* 19/4/2016 added code*/
            RectTransform ct = GetComponent<RectTransform>();
            RectTransform temp = Instantiate(ct) as RectTransform;
            temp.name = ct.name;
            temp.localScale = ct.lossyScale;
            temp.parent = SelectedList;
            /* end of added code*/

            //transform.parent = SelectedList;
        }
        else
        {
            /* 19/4/2016 added code*/
            Destroy(gameObject);
            /* end of added code*/

            //transform.parent = moodList;
        }
    }
}
