using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Custom;

public class NavigateAndSelectMode1 : MonoBehaviour
{
    public RectTransform moodList;
    public List<int> SelectedMoods;
    public RectTransform SelectedList;
    public RectTransform CurrentList;

    public List<Text> MoodsTexts;
    public List<Text> SelectedMoodsTexts;
    public Text CurrentText;
    public Color UnSelectedColor;
    public Color SelectedColor;

    public GameObject InputManager;

    public Text ModeText;


    int Index = 0;
    List<Animator> StagesAnimators;

    RectTransform[] moodsArray; // 
    int[] moodsPlayingNo; // text number which indecates how many times the player want to paly this mood

    AudioSource sfxNavigate;
    AudioSource sfxSelect;
    AudioSource sfxNext;
    AudioSource sfxBack;
    AudioSource sfxDeselect;

    // Use this for initialization
    #region 
    void Awake()
    {
        CurrentList = moodList;
        MoodsTexts = new List<Text>(moodList.childCount);
        moodsArray = new RectTransform[moodList.childCount];
        moodsPlayingNo = new int[moodList.childCount];

        StagesAnimators = new List<Animator>(moodList.childCount);

        for (int i = 0; i < (moodList.childCount); i++)
        {
            MoodsTexts.Add(moodList.GetChild(i).GetChild(0).GetComponent<Text>());
            moodsArray[i] = moodList.GetChild(i).GetComponent<RectTransform>();
            moodsPlayingNo[i] = 0;
            StagesAnimators.Add(moodList.GetChild(i).GetComponent<Animator>());
        }
        CurrentText = MoodsTexts[Index];
        CurrentText.color = SelectedColor;
        ModeText.text = CurrentText.text;

        SelectedMoodsTexts = new List<Text>();

        sfxNavigate = GameObject.FindGameObjectWithTag("sfxNavigate").GetComponent<AudioSource>();
        sfxSelect = GameObject.FindGameObjectWithTag("sfxSelect").GetComponent<AudioSource>();
        //sfxNext = GameObject.FindGameObjectWithTag("sfxNext").GetComponent<AudioSource>();
        //sfxBack = GameObject.FindGameObjectWithTag("sfxBack").GetComponent<AudioSource>();
        sfxDeselect = GameObject.FindGameObjectWithTag("sfxDeselect").GetComponent<AudioSource>();

    }
    void Start()
    {
        InputManager.GetComponent<InputManagerScript>().P1jumpInitiated += this.SelectItem;
        //InputManager.GetComponent<InputManagerScript>().P2jumpInitiated += this.SelectItem;
        //InputManager.GetComponent<InputManagerScript>().P3jumpInitiated += this.SelectItem;
        //InputManager.GetComponent<InputManagerScript>().P4jumpInitiated += this.SelectItem;

        InputManager.GetComponent<InputManagerScript>().P1movementChanged += this.Navigate;
        //InputManager.GetComponent<InputManagerScript>().P2movementChanged += this.Navigate;
        //InputManager.GetComponent<InputManagerScript>().P3movementChanged += this.Navigate;
        //InputManager.GetComponent<InputManagerScript>().P4movementChanged += this.Navigate;

        InputManager.GetComponent<InputManagerScript>().P1_O_Initiated += this.RemoveItemFromList;
        //InputManager.GetComponent<InputManagerScript>().P2_O_Initiated += this.RemoveItemFromList;
        //InputManager.GetComponent<InputManagerScript>().P3_O_Initiated += this.RemoveItemFromList;
        //InputManager.GetComponent<InputManagerScript>().P4_O_Initiated += this.RemoveItemFromList;
    }
    #endregion
    #region subscribed functions
    public void SelectItem(object sender, EventArgs e)
    {
        ChooseItemFromList();
    }
    public void Navigate(object sender, MovementEventArgs e)
    {
        // 3/5/2016 new Mood Selection 
        //if (Mathf.Abs(e.YAxis) > 0.2f)
        //{
        //    NavigateBetweenItemsInList(((e.YAxis > 0) ? 1 : ((e.YAxis == 0) ? 0 : -1)));
        //}
        //else if (Mathf.Abs(e.XAxis) > 0.2f)
        //{
        //    NavigateBetweenLists(((e.XAxis > 0) ? 1 : ((e.XAxis == 0) ? 0 : -1)));
        //}

        if (Mathf.Abs(e.XAxis) > 0.2f)
        {
            NavigateBetweenItemsInList(((e.XAxis > 0) ? 1 : ((e.XAxis == 0) ? 0 : -1)));
        }

        //end of 3/5/2016
    }
    #endregion

    public void NavigateBetweenItemsInList(float Val)
    {
        sfxNavigate.Play();
        if (CurrentList.childCount < 2) { return; }
        if (Val < 0)
        {
            //Index = (Index == 0) ? CurrentList.childCount - 1 : Index - 1;
            MoveLeft();
        }
        else if (Val > 0)
        {
            //Index = (Index == CurrentList.childCount - 1) ? 0 : Index + 1;
            MoveRight();
        }


        CurrentText.color = UnSelectedColor;
        if (CurrentList == moodList)
        {
            CurrentText = MoodsTexts[Index];
        }
        //else if(CurrentList == SelectedList)
        //{
        //    CurrentText = SelectedMoodsTexts[Index];
        //}
        CurrentText.color = SelectedColor;
        ModeText.text = CurrentText.text;
    }
    public void ChooseItemFromList()
    {
        sfxSelect.Play();
        if (CurrentList == moodList)
        {
            //string ct = moodList.GetChild(Index).GetChild(1).GetComponent<Text>().text;
            //ct.GetChild(1).GetComponent<Text>().text += 1; 
            moodsPlayingNo[Index] += 1;
            moodsArray[Index].GetChild(1).GetComponent<Text>().text = moodsPlayingNo[Index].ToString();
            moodsArray[Index].GetChild(1).GetComponent<Animator>().SetTrigger("Scale");
            SelectedMoods.Add(int.Parse(moodsArray[Index].name));

            //RectTransform temp = Instantiate(ct) as RectTransform;
            //temp.name = ct.name;
            // temp.localScale = ct.lossyScale;
            // temp.parent = SelectedList;
            //SelectedMoodsTexts.Add(temp.GetChild(0).GetComponent<Text>());
            //SelectedMoodsTexts[SelectedMoodsTexts.Count - 1].color = UnSelectedColor;
        }

    }
    public void RemoveItemFromList(object sender, EventArgs e)
    {
        sfxDeselect.Play();
        if (int.Parse(moodsArray[Index].GetChild(1).GetComponent<Text>().text) > 0)
        {
            moodsPlayingNo[Index] -= 1;
            moodsArray[Index].GetChild(1).GetComponent<Text>().text = moodsPlayingNo[Index].ToString();
            moodsArray[Index].GetChild(1).GetComponent<Animator>().SetTrigger("Rotate");
            SelectedMoods.Remove(int.Parse(moodsArray[Index].name));
            // SelectedMoods.Add(int.Parse(moodsArray[Index].name));
        }
    }

    void MoveRight()
    {
        if (Index == StagesAnimators.Count - 1) { return; }
        if (Index > 0)
        {
            StagesAnimators[Index - 1].Play("MoveOutLeft");
        }
        StagesAnimators[Index].Play("MoveToLeft");
        if (Index + 1 < StagesAnimators.Count)
        {
            StagesAnimators[Index + 1].Play("MoveToMiddleFrom Right");
        }
        if (Index + 2 < StagesAnimators.Count)
        {
            StagesAnimators[Index + 2].Play("MoveInRight");
        }
       // RightArrowAnimator.Play("ActRight");
        Index++;
    }
    void MoveLeft()
    {
        if (Index == 0) { return; }
        if (Index > 1)
        {
            StagesAnimators[Index - 2].Play("MoveInLeft");
        }
        if (Index > 0)
        {
            StagesAnimators[Index - 1].Play("ModeToMiddleFromLeft");
        }
        StagesAnimators[Index].Play("MoveToRight");
        if (Index + 1 < StagesAnimators.Count)
        {
            StagesAnimators[Index + 1].Play("MoveOutRight");
        }
       // LeftArrowAnimator.Play("ActLeft");
        Index--;
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
