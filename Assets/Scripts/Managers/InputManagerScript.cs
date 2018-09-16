using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Custom;
using System;

public class InputManagerScript : MonoBehaviour
{
    #region P1 attributes
    float P1_xAxis;
    float P1_yAxis;
    // float P1_yAxis;
    bool P1Jump;
    public event EventHandler<MovementEventArgs> P1movementChanged;
    public event EventHandler<MovementEventArgs> P1jumpInitiated;
    /*20/4/2016 added code*/
    bool P1_X;
    bool P1_O;
    bool P1_Select;
    bool P1_Start;
    public event EventHandler<MovementEventArgs> P1_X_Initiated;
    public event EventHandler<MovementEventArgs> P1_O_Initiated;
    public event EventHandler<MovementEventArgs> P1_Select_Initiated; //go backward;
    public event EventHandler<MovementEventArgs> P1_START_Initiated; //go next
    /*end of added code*/
    #endregion
    #region P2 attributes
    float P2_xAxis;
    float P2_yAxis;
    //float P2_yAxis;
    bool P2Jump;
    public event EventHandler<MovementEventArgs> P2movementChanged;
    public event EventHandler<MovementEventArgs> P2jumpInitiated;
    /*20/4/2016 added code*/
    bool P2_X;
    bool P2_O;
    bool P2_Select;
    bool P2_Start;
    public event EventHandler<MovementEventArgs> P2_X_Initiated;
    public event EventHandler<MovementEventArgs> P2_O_Initiated;
    public event EventHandler<MovementEventArgs> P2_Select_Initiated;
    public event EventHandler<MovementEventArgs> P2_START_Initiated;
    /*end of added code*/
    #endregion
    #region P3 attributes
    float P3_xAxis;
    float P3_yAxis;
    //float P3_yAxis;
    bool P3Jump;
    public event EventHandler<MovementEventArgs> P3movementChanged;
    public event EventHandler<MovementEventArgs> P3jumpInitiated;
    /*20/4/2016 added code*/
    bool P3_X;
    bool P3_O;
    bool P3_Select;
    bool P3_Start;
    public event EventHandler<MovementEventArgs> P3_X_Initiated;
    public event EventHandler<MovementEventArgs> P3_O_Initiated;
    public event EventHandler<MovementEventArgs> P3_Select_Initiated;
    public event EventHandler<MovementEventArgs> P3_START_Initiated;
    /*end of added code*/
    #endregion
    #region P4 attributes
    float P4_xAxis;
    float P4_yAxis;
    //float P4_yAxis;
    bool P4Jump;
    public event EventHandler<MovementEventArgs> P4movementChanged;
    public event EventHandler<MovementEventArgs> P4jumpInitiated;
    /*20/4/2016 added code*/
    bool P4_X;
    bool P4_O;
    bool P4_Select;
    bool P4_Start;
    public event EventHandler<MovementEventArgs> P4_X_Initiated;
    public event EventHandler<MovementEventArgs> P4_O_Initiated;
    public event EventHandler<MovementEventArgs> P4_Select_Initiated;
    public event EventHandler<MovementEventArgs> P4_START_Initiated;
    /*end of added code*/
    #endregion
    
    bool flag = true;
    // Update is called once per frame
    void Update()
    {
        #region JoyStick 1 Input
        P1_xAxis = Input.GetAxis("P1Hori");
        P1_yAxis = Input.GetAxis("P1Vertical");
        P1Jump = Input.GetKeyDown(KeyCode.Joystick1Button2);
        if (/*flag && */(Math.Abs(P1_xAxis) >= 0.1 || Math.Abs(P1_yAxis) >= 0.1f))
        {
            //flag = false;
            P1_OnMovementChanged(new MovementEventArgs() { XAxis = P1_xAxis, YAxis = P1_yAxis, JoyStickID = 1 });
        }
        //else {
        //    flag = false;
        //}
        if (P1Jump)
        {
            P1_OnJumpInitiated(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 1 });
        }
        /* 20/4/2016 added code */
        P1_X = Input.GetKeyDown(KeyCode.Joystick1Button2);
        if (P1_X)
        {
            P1_On_X_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 1 });
        }
        P1_O = Input.GetKeyDown(KeyCode.Joystick1Button1);
        if (P1_O)
        {
            P1_On_O_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 1 });
        }
        P1_Select = Input.GetKeyDown(KeyCode.Joystick1Button8);
        if (P1_Select)
        {
            P1_On_Select_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 1 });
        }
        P1_Start = Input.GetKeyDown(KeyCode.Joystick1Button9);
        if (P1_Start)
        {
            P1_On_START_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 1 });
        }
        /* 20/4/2016 end of added code */
        #endregion
        #region JoyStick 2 Input
        P2_xAxis = Input.GetAxis("P2Hori");
        P2_yAxis = Input.GetAxis("P2Vertical");
        P2Jump = Input.GetKeyDown(KeyCode.Joystick2Button2);
        if (Math.Abs(P2_xAxis) >= 0.1 || Math.Abs(P2_yAxis) >= 0.1f)
        {
            P2_OnMovementChanged(new MovementEventArgs() { XAxis = P2_xAxis, YAxis = P2_yAxis, JoyStickID = 2});
        }
        if (P2Jump)
        {
            P2_OnJumpInitiated(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 2 });
        }

        /* 20/4/2016 added code */
        P2_X = Input.GetKeyDown(KeyCode.Joystick2Button2);
        if (P2_X)
        {
            P2_On_X_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 2 });
        }
        P2_O = Input.GetKeyDown(KeyCode.Joystick2Button1);
        if (P2_O)
        {
            P2_On_O_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 2 });
        }
        P2_Select = Input.GetKeyDown(KeyCode.Joystick2Button8);
        if (P2_Select)
        {
            P2_On_Select_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 2 });
        }
        P2_Start = Input.GetKeyDown(KeyCode.Joystick2Button9);
        if (P2_Start)
        {
            P2_On_START_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 2 });
        }
        /* 20/4/2016 end of added code */
        #endregion
        #region JoyStick 3 Input
        P3_xAxis = Input.GetAxis("P3Hori");
        P3_yAxis = Input.GetAxis("P3Vertical");
        P3Jump = Input.GetKeyDown(KeyCode.Joystick3Button2);
        if (Math.Abs(P3_xAxis) >= 0.1 || Math.Abs(P3_yAxis) >= 0.1f)
        {
            P3_OnMovementChanged(new MovementEventArgs() { XAxis = P3_xAxis, YAxis = P3_yAxis, JoyStickID = 3 });
        }
        if (P3Jump)
        {
            P3_OnJumpInitiated(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 3 });
        }


        /* 20/4/2016 added code */
        P3_X = Input.GetKeyDown(KeyCode.Joystick3Button2);
        if (P3_X)
        {
            P3_On_X_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 3 });
        }
        P3_O = Input.GetKeyDown(KeyCode.Joystick3Button1);
        if (P3_O)
        {
            P3_On_O_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 3 });
        }
        P3_Select = Input.GetKeyDown(KeyCode.Joystick3Button8);
        if (P3_Select)
        {
            P3_On_Select_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 3 });
        }
        P3_Start = Input.GetKeyDown(KeyCode.Joystick3Button9);
        if (P3_Start)
        {
            P3_On_START_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 3 });
        }
        /* 20/4/2016 end of added code */
        #endregion
        #region JoyStick 4 Input
        P4_xAxis = Input.GetAxis("P4Hori");
        P4_yAxis = Input.GetAxis("P4Vertical");
        P4Jump = Input.GetKeyDown(KeyCode.Joystick4Button2);
        if (Math.Abs(P4_xAxis) >= 0.1f || Math.Abs(P4_yAxis) >= 0.1f)
        {
            P4_OnMovementChanged(new MovementEventArgs() { XAxis = P4_xAxis, YAxis = P4_yAxis, JoyStickID = 4 });
        }
        if (P4Jump)
        {
            P4_OnJumpInitiated(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 4 });
        }


        /* 20/4/2016 added code */
        P4_X = Input.GetKeyDown(KeyCode.Joystick4Button2);
        if (P4_X)
        {
            P4_On_X_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 4 });
        }
        P4_O = Input.GetKeyDown(KeyCode.Joystick4Button1);
        if (P4_O)
        {
            P4_On_O_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 4 });
        }
        P4_Select = Input.GetKeyDown(KeyCode.Joystick4Button8);
        if (P4_Select)
        {
            P4_On_Select_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 4 });
        }
        P4_Start = Input.GetKeyDown(KeyCode.Joystick4Button9);
        if (P4_Start)
        {
            P4_On_START_Pressed(new MovementEventArgs() { XAxis = 0, YAxis = 0, JoyStickID = 4 });
        }
        /* 20/4/2016 end of added code */
        #endregion
    }

    IEnumerator EnableJoyStick(int index, float time)
    {
        yield return new WaitForSeconds(time);
        switch (index)
        {
            case 1:
                JoyStick_1_Enabled = true;
                break;
            case 2:
                JoyStick_2_Enabled = true;
                break;
            case 3:
                JoyStick_3_Enabled = true;
                break;
            case 4:
                JoyStick_4_Enabled = true;
                break;
        }
    }

    #region JoyStick 1 Handller
    bool JoyStick_1_Enabled = true;
   

    protected virtual void P1_OnMovementChanged(MovementEventArgs e)
    {
        if (P1movementChanged != null && JoyStick_1_Enabled)
        {
            JoyStick_1_Enabled = false;
            P1movementChanged(this, e);
#if UNITY_WSA_10_0
            StartCoroutine(EnableJoyStick(1, 2f));
#else
             StartCoroutine(EnableJoyStick(1, 0.2f));
#endif
            // StartCoroutine(EnableJoyStick(1, 0.2f));
        }
    }
    protected virtual void P1_OnJumpInitiated(MovementEventArgs e)
    {
        if (P1jumpInitiated != null )
        {
            P1jumpInitiated(this, e);
        }
    }
    /* 20/4/2016 added code */
    protected virtual void P1_On_X_Pressed(MovementEventArgs e)
    {
        if (P1_X_Initiated != null)
        {
            P1_X_Initiated(this, e);
        }
    }
    protected virtual void P1_On_O_Pressed(MovementEventArgs e)
    {
        if (P1_O_Initiated != null)
        {
            P1_O_Initiated(this, e);
        }
    }
    protected virtual void P1_On_Select_Pressed(MovementEventArgs e)
    {
        if (P1_Select_Initiated != null)
        {
            P1_Select_Initiated(this, e);
        }
    }
    protected virtual void P1_On_START_Pressed(MovementEventArgs e)
    {
        if (P1_START_Initiated != null)
        {
            P1_START_Initiated(this, e);
        }
    }
    /* end of added code */
    #endregion

    #region JoyStick 2 Handller
    bool JoyStick_2_Enabled = true;
   
    protected virtual void P2_OnMovementChanged(MovementEventArgs e)
    {
        if (P2movementChanged != null && JoyStick_2_Enabled)
        {
            JoyStick_2_Enabled = false;
            P2movementChanged(this, e);
#if UNITY_WSA_10_0
            StartCoroutine(EnableJoyStick(2, 2f));
#else
             StartCoroutine(EnableJoyStick(2, 0.2f));
#endif
        }
    }
    protected virtual void P2_OnJumpInitiated(MovementEventArgs e)
    {
        if (P2jumpInitiated != null)
        {
            P2jumpInitiated(this, e);
        }
    }


    /* 20/4/2016 added code */
    protected virtual void P2_On_X_Pressed(MovementEventArgs e)
    {
        if (P2_X_Initiated != null)
        {
            P2_X_Initiated(this, e);
        }
    }
    protected virtual void P2_On_O_Pressed(MovementEventArgs e)
    {
        if (P2_O_Initiated != null)
        {
            P2_O_Initiated(this, e);
        }
    }
    protected virtual void P2_On_Select_Pressed(MovementEventArgs e)
    {
        if (P2_Select_Initiated != null)
        {
            P2_Select_Initiated(this, e);
        }
    }
    protected virtual void P2_On_START_Pressed(MovementEventArgs e)
    {
        if (P2_START_Initiated != null)
        {
            P2_START_Initiated(this, e);
        }
    }
    /* end of added code */
    #endregion

    #region JoyStick 3 Handller
    bool JoyStick_3_Enabled = true;
    protected virtual void P3_OnMovementChanged(MovementEventArgs e)
    {
        if (P3movementChanged != null && JoyStick_3_Enabled)
        {
            JoyStick_3_Enabled = false;
            P3movementChanged(this, e);
#if UNITY_WSA_10_0
            StartCoroutine(EnableJoyStick(3, 2f));
#else
             StartCoroutine(EnableJoyStick(3, 0.2f));
#endif
        }
    }
    protected virtual void P3_OnJumpInitiated(MovementEventArgs e)
    {
        if (P3jumpInitiated != null)
        {
            P3jumpInitiated(this, e);
        }
    }


    /* 20/4/2016 added code */
    protected virtual void P3_On_X_Pressed(MovementEventArgs e)
    {
        if (P3_X_Initiated != null)
        {
            P3_X_Initiated(this, e);
        }
    }
    protected virtual void P3_On_O_Pressed(MovementEventArgs e)
    {
        if (P3_O_Initiated != null)
        {
            P3_O_Initiated(this, e);
        }
    }
    protected virtual void P3_On_Select_Pressed(MovementEventArgs e)
    {
        if (P3_Select_Initiated != null)
        {
            P3_Select_Initiated(this, e);
        }
    }
    protected virtual void P3_On_START_Pressed(MovementEventArgs e)
    {
        if (P3_START_Initiated != null)
        {
            P3_START_Initiated(this, e);
        }
    }
    /* end of added code */
    #endregion

    #region JoyStick 4 Handller

    bool JoyStick_4_Enabled = true;
    protected virtual void P4_OnMovementChanged(MovementEventArgs e)
    {
        if (P4movementChanged != null && JoyStick_4_Enabled)
        {
            JoyStick_4_Enabled = false;
            P4movementChanged(this, e);
#if UNITY_WSA_10_0
            StartCoroutine(EnableJoyStick(4, 2f));
#else
             StartCoroutine(EnableJoyStick(4, 0.2f));
#endif
        }
    }
    protected virtual void P4_OnJumpInitiated(MovementEventArgs e)
    {
        if (P4jumpInitiated != null)
        {
            P4jumpInitiated(this, e);
        }
    }


    /* 20/4/2016 added code */
    protected virtual void P4_On_X_Pressed(MovementEventArgs e)
    {
        if (P4_X_Initiated != null)
        {
            P4_X_Initiated(this, e);
        }
    }
    protected virtual void P4_On_O_Pressed(MovementEventArgs e)
    {
        if (P4_O_Initiated != null)
        {
            P4_O_Initiated(this, e);
        }
    }
    protected virtual void P4_On_Select_Pressed(MovementEventArgs e)
    {
        if (P4_Select_Initiated != null)
        {
            P4_Select_Initiated(this, e);
        }
    }
    protected virtual void P4_On_START_Pressed(MovementEventArgs e)
    {
        if (P4_START_Initiated != null)
        {
            P4_START_Initiated(this, e);
        }
    }
    /* end of added code */
    #endregion

}
