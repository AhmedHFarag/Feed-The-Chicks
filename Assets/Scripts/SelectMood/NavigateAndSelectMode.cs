using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Custom;

public class NavigateAndSelectMode : MonoBehaviour {
    public RectTransform moodList;
    public RectTransform SelectedList;
    public RectTransform CurrentList;

    public List<Text> MoodsTexts;
    public List<Text> SelectedMoodsTexts;
    public Text CurrentText;
    public Color UnSelectedColor;
    public Color SelectedColor;

    public GameObject InputManager;
    
    int Index = 0;
    // Use this for initialization
    #region 
    void Awake()
    {
        CurrentList = moodList;
        MoodsTexts = new List<Text>(moodList.childCount);
        for (int i = 0; i < (moodList.childCount); i++)
        {
            MoodsTexts.Add(moodList.GetChild(i).GetChild(0).GetComponent<Text>());
        }
        CurrentText = MoodsTexts[0];
        CurrentText.color = SelectedColor;

        SelectedMoodsTexts = new List<Text>();
    }
    void Start()
    {
        InputManager.GetComponent<InputManagerScript>().P1jumpInitiated += this.SelectItem;
        InputManager.GetComponent<InputManagerScript>().P2jumpInitiated += this.SelectItem;
        InputManager.GetComponent<InputManagerScript>().P3jumpInitiated += this.SelectItem;
        InputManager.GetComponent<InputManagerScript>().P4jumpInitiated += this.SelectItem;

        InputManager.GetComponent<InputManagerScript>().P1movementChanged += this.Navigate;
        InputManager.GetComponent<InputManagerScript>().P2movementChanged += this.Navigate;
        InputManager.GetComponent<InputManagerScript>().P3movementChanged += this.Navigate;
        InputManager.GetComponent<InputManagerScript>().P4movementChanged += this.Navigate;
    }
    #endregion
    #region subscribed functions
    public void SelectItem(object sender, EventArgs e)
    {
        ChooseItemFromList();
    }
    public void Navigate(object sender, MovementEventArgs e) {

        if (Mathf.Abs(e.YAxis) > 0.2f)
        {
            NavigateBetweenItemsInList(((e.YAxis > 0) ? 1 : ((e.YAxis == 0) ? 0 : -1)));
        }
        else if (Mathf.Abs(e.XAxis) > 0.2f)
        {
            NavigateBetweenLists(((e.XAxis > 0) ? 1 : ((e.XAxis == 0) ? 0 : -1)));
        }

    }
    #endregion

    public void NavigateBetweenItemsInList(float Val)
    {
        Debug.Log(Val);
        if (CurrentList.childCount < 2) { return; }
        if (Val > 0)
        {
            Index = (Index == 0) ? CurrentList.childCount - 1 : Index - 1;
        }
        else
        {
            Index = (Index == CurrentList.childCount - 1) ? 0 : Index + 1;            
        }

        Debug.Log(Index);
        CurrentText.color = UnSelectedColor;
        if (CurrentList == moodList)
        {
            CurrentText = MoodsTexts[Index];
        }
        else if (CurrentList == SelectedList)
        {
            CurrentText = SelectedMoodsTexts[Index];
        }
        CurrentText.color = SelectedColor;
    }
    public void NavigateBetweenLists(float Val)
    {
        if(Val == 0) { return; }
        if (Val > 0)
        {
            if(CurrentList == moodList)
            {
                if (SelectedList.childCount > 0)
                {
                    CurrentText.color = UnSelectedColor;
                    CurrentList = SelectedList;
                    Index = 0;
                    CurrentText = SelectedMoodsTexts[Index];
                    CurrentText.color = SelectedColor;
                }
            }
        }
        else if (Val < 0)
        {
            if (CurrentList == SelectedList)
            {
                CurrentText.color = UnSelectedColor;
                CurrentList = moodList;                
                Index = 0;
                CurrentText = MoodsTexts[Index];
                CurrentText.color = SelectedColor;
            }
        }
    }
    public void ChooseItemFromList()
    {
        if(CurrentList == moodList)
        {
            RectTransform ct = moodList.GetChild(Index).GetComponent<RectTransform>();
            RectTransform temp = Instantiate(ct) as RectTransform;
            temp.name = ct.name;
            temp.localScale = ct.lossyScale;
            temp.parent = SelectedList;
            SelectedMoodsTexts.Add(temp.GetChild(0).GetComponent<Text>());
            SelectedMoodsTexts[SelectedMoodsTexts.Count - 1].color = UnSelectedColor;
        }
        else if (CurrentList == SelectedList)
        {
            Destroy(SelectedList.GetChild(Index).gameObject/*SelectedMoodsTexts[Index].gameObject.transform.parent.gameObject*/);
            SelectedMoodsTexts.RemoveAt(Index);
            Index = 0;
            Debug.Log(SelectedList.childCount);
            if (SelectedList.childCount == 1)
            {
                CurrentList = moodList;
                CurrentText = MoodsTexts[0];
                CurrentText.color = SelectedColor;
            }
            else
            if (SelectedList.childCount > 1)
            {
                CurrentText = SelectedMoodsTexts[0];
                CurrentText.color = SelectedColor;
            }
        }
    }

    //public void OnClick()
    //{
    //    if (transform.parent == moodList)
    //    {
    //        /* 19/4/2016 added code*/
    //        RectTransform ct = GetComponent<RectTransform>();
    //        RectTransform temp = Instantiate(ct) as RectTransform;
    //        temp.name = ct.name;
    //        temp.localScale = ct.lossyScale;
    //        temp.parent = SelectedList;
    //        /* end of added code*/

    //        //transform.parent = SelectedList;
    //    }
    //    else
    //    {
    //        /* 19/4/2016 added code*/
    //        Destroy(gameObject);
    //        /* end of added code*/

    //        //transform.parent = moodList;
    //    }
    //}
}
