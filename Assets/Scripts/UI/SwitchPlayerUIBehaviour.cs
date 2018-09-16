using UnityEngine;
using System.Collections;
using Custom;
using System;
using UnityEngine.UI;

public class SwitchPlayerUIBehaviour : MonoBehaviour
{
    //
    public Sprite[] avatarsUI;
    //test animator
    public RuntimeAnimatorController[] avatarsAnimator;

    /*19/4/2016 added code*/
    static public bool[] AvatarSelected;
    /*end of added*/

    int index = -1;
    public Image avatar;

    bool isPressed = false;

    void Awake()
    {
        /*19/4/2016 added code*/
        AvatarSelected = new bool[avatarsUI.Length];
        for (int i = 0; i < AvatarSelected.Length; i++)
        {
            AvatarSelected[i] = false;
        }
        /*end of added code*/
    }

    public void Switch(object sender, MovementEventArgs e)
    {

        //this.transform.GetChild(0).GetComponent<Text>().text = "ID: " + e.JoyStickID.ToString() + "Value: " + e.XAxis.ToString();
        this.transform.GetChild(1).GetComponent<Text>().text = "UnSelected";


        GameManager.Current.players.Remove(e.JoyStickID);
        #region Past Code
        /**/
        //if (e.XAxis > .2f /*&& !isPressed*/)
        //{
        //    if (index < avatarsUI.Length - 1){
        //        index++;
        //    }else{
        //        index = 0;
        //    }
        //    avatar.sprite = avatarsUI[index];
        //    //isPressed = true;
        //}
        //else if (e.XAxis < -.2f/* && !isPressed*/)
        //{
        //    if (index > 0)
        //    {
        //        index--;
        //    }
        //    else
        //    {
        //        index = avatarsUI.Length - 1;
        //    }
        //    avatar.sprite = avatarsUI[index];
        // //   isPressed = true;
        //}
        #endregion
        /**********************/
        /*19/4/2016 added code*/
        int tempIndex = index;
        int count = 0;
        if (e.XAxis > .2f /*&& !isPressed*/)
        {
            while (count < avatarsUI.Length)
            {
                count++;
                tempIndex = (tempIndex < avatarsUI.Length - 1) ? (tempIndex + 1) : 0;

                if (!AvatarSelected[tempIndex])
                {
                    if (index > -1) { AvatarSelected[index] = false; }
                    index = tempIndex;
                    AvatarSelected[index] = true;
                    avatar.sprite = avatarsUI[index];
                    //test animator
                    avatar.transform.GetComponent<Animator>().runtimeAnimatorController = avatarsAnimator[index];

                    break;
                }
            }
        }
        else if (e.XAxis < -.2f/* && !isPressed*/)
        {
            while (count < avatarsUI.Length)
            {
                count++;
                tempIndex = (tempIndex > 0) ? (tempIndex - 1) : avatarsUI.Length - 1;

                if (!AvatarSelected[tempIndex])
                {
                    if (index > -1) { AvatarSelected[index] = false; }
                    index = tempIndex;
                    AvatarSelected[index] = true;
                    avatar.sprite = avatarsUI[index];
                    //test animator
                    avatar.transform.GetComponent<Animator>().runtimeAnimatorController = avatarsAnimator[index];
                    break;
                }
            }
        }
        /*end of added code*/
    }
    public void Accept(object sender, MovementEventArgs e)
    {
        for (int i = 0; i < GameManager.Current.players.Count; i++)
        {
            Debug.Log("playerlist " + i + "  : " + GameManager.Current.players[i]);
        }
        if (!GameManager.Current.players.Contains(e.JoyStickID)) { GameManager.Current.players.Add(e.JoyStickID); }

        // //test animator
        avatar.transform.GetComponent<Animator>().SetTrigger("Selected");
        //this.transform.GetChild(0).GetComponent<Text>().text = "Accept";
        this.transform.GetChild(1).GetComponent<Text>().text = "Selected";
        isPressed = true;
    }
}
