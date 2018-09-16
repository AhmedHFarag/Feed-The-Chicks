using UnityEngine;
using System.Collections;

public class IntroChicksController : MonoBehaviour
{

    public delegate void useSpecialAbility();

    public static event useSpecialAbility onUseSpecialAbility;

    StanderedController controller;
    IntroExtendedFeature extendedController;
    IntroSpecialAbility specialAbilityController;
    Healthbar playerHealth;
    // public event Action OnDeath;
    public int id = 1;

    public GameObject dustGameObj;

    public Color chickColor;

    [HideInInspector]
    public bool hasIncSpeedAbility = false;
    [HideInInspector]
    public bool hasDecSpeedAbility = false;
    [HideInInspector]
    public bool hasReverseControllerAbility = false;
    [HideInInspector]
    public bool hasAttackAbility = false;
    [HideInInspector]
    public bool hasDefenedAbility = false;
    Animator anim;

    //3ack
    Animator CameraAnimator;
    Animator PlayerAnimator;

    ////test in inspector
    //    public float score =0;

    // Use this for initialization
    void Awake()
    {

        controller = GetComponent<StanderedController>();
        extendedController = GetComponent<IntroExtendedFeature>();
        specialAbilityController = GetComponent<IntroSpecialAbility>();
        playerHealth = GetComponent<Healthbar>();
        anim = GetComponent<Animator>();
        CameraAnimator = Camera.main.GetComponent<Animator>();
        PlayerAnimator = this.gameObject.GetComponent<Animator>();
        if (chickColor == null)
        {
            chickColor = Color.white;
        }

        //3ack
        PlayerAnimator = this.gameObject.GetComponent<Animator>();

        // dustParticalSystem = dustGameObj.GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (!playersList.current.isPaused)
        {
            float xAxis = Input.GetAxis(string.Format("P{0}Hori", id));

            if (controller.IsGrounded() && dustGameObj)
            {
                dustGameObj.SetActive(true);
            }
            else
            {
                dustGameObj.SetActive(false);
            }

            CharcterController(xAxis);
            Jumping();

            if (extendedController)
            {
                Dash(xAxis);
                Bashing(xAxis);
            }
            if (specialAbilityController)
            {
                UseAbilities();
            }
        }
    }

    void LateUpdate()
    {
        if (!playersList.current.isPaused)
        {
            if (extendedController)
            {
                if (!extendedController.ChargeBashing())
                    extendedController.ChargeBashing();
            }
        }
    }
    void CharcterController(float xAxis)
    {
        anim.SetFloat("xSpeed", Mathf.Abs(xAxis));
        controller.Move(xAxis);
        anim.SetBool("grounded", controller.IsGrounded());
    }
#if UNITY_WSA_10_0	
    
    void Bashing(float xAxis)
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && id == 1 ||
        Input.GetKeyDown(KeyCode.Joystick2Button0) && id == 2 ||
        Input.GetKeyDown(KeyCode.Joystick3Button0) && id == 3 ||
        Input.GetKeyDown(KeyCode.Joystick4Button0) && id == 4 ||
        Input.GetKeyDown(KeyCode.Joystick5Button0) && id == 5 ||
        Input.GetKeyDown(KeyCode.Joystick6Button0) && id == 6 ||
        Input.GetKeyDown(KeyCode.Joystick7Button0) && id == 7 ||
        Input.GetKeyDown(KeyCode.Joystick8Button0) && id == 8
        )
        {
            extendedController.IsBashing(true);
            anim.SetTrigger("isBashing");
        }
        else if (Input.GetKeyUp(KeyCode.Joystick1Button0) && id == 1 ||
                Input.GetKeyUp(KeyCode.Joystick2Button0) && id == 2 ||
        Input.GetKeyUp(KeyCode.Joystick3Button0) && id == 3 ||
        Input.GetKeyUp(KeyCode.Joystick4Button0) && id == 4 ||
        Input.GetKeyUp(KeyCode.Joystick5Button0) && id == 5 ||
        Input.GetKeyUp(KeyCode.Joystick6Button0) && id == 6 ||
        Input.GetKeyUp(KeyCode.Joystick7Button0) && id == 7 ||
        Input.GetKeyUp(KeyCode.Joystick8Button0) && id == 8)
        {
            extendedController.IsBashing(false);
            extendedController.ChargeBashing();
        }
    }
    void Dash(float xAxis)
    {
    #region Dash
        if (Input.GetKeyDown(KeyCode.Joystick1Button3) && id == 1 ||
            Input.GetKeyDown(KeyCode.Joystick2Button3) && id == 2 ||
            Input.GetKeyDown(KeyCode.Joystick3Button3) && id == 3 ||
            Input.GetKeyDown(KeyCode.Joystick4Button3) && id == 4 ||
            Input.GetKeyDown(KeyCode.Joystick5Button3) && id == 5 ||
            Input.GetKeyDown(KeyCode.Joystick6Button3) && id == 6 ||
            Input.GetKeyDown(KeyCode.Joystick7Button3) && id == 7 ||
            Input.GetKeyDown(KeyCode.Joystick8Button3) && id == 8)
        {
            extendedController.setTrailRenderer(true);
            extendedController.Dash(xAxis);
        }
        //on key up
        else if (Input.GetKeyUp(KeyCode.Joystick1Button3) && id == 1 ||
                Input.GetKeyUp(KeyCode.Joystick2Button3) && id == 2 ||
                Input.GetKeyUp(KeyCode.Joystick3Button3) && id == 3 ||
                Input.GetKeyUp(KeyCode.Joystick4Button3) && id == 4 ||
                Input.GetKeyUp(KeyCode.Joystick5Button3) && id == 5 ||
                Input.GetKeyUp(KeyCode.Joystick6Button3) && id == 6 ||
                Input.GetKeyUp(KeyCode.Joystick7Button3) && id == 7 ||
                Input.GetKeyUp(KeyCode.Joystick8Button3) && id == 8)
        {
            extendedController.setTrailRenderer(false);
        }
    #endregion
     }
    void Jumping()
    {
    #region jumping
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && id == 1 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick2Button2) && id == 2 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick3Button2) && id == 3 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick4Button2) && id == 4 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick5Button2) && id == 5 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick6Button2) && id == 6 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick7Button2) && id == 7 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick8Button2) && id == 8 && controller.IsGrounded())
        {
            controller.Jump();
            anim.SetTrigger("jump");
        }
    #endregion
    }

#else  

    void Bashing(float xAxis)
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && id == 1 ||
        Input.GetKeyDown(KeyCode.Joystick2Button2) && id == 2 ||
        Input.GetKeyDown(KeyCode.Joystick3Button2) && id == 3 ||
        Input.GetKeyDown(KeyCode.Joystick4Button2) && id == 4 ||
        Input.GetKeyDown(KeyCode.Joystick5Button2) && id == 5 ||
        Input.GetKeyDown(KeyCode.Joystick6Button2) && id == 6 ||
        Input.GetKeyDown(KeyCode.Joystick7Button2) && id == 7 ||
        Input.GetKeyDown(KeyCode.Joystick8Button2) && id == 8
        )
        {
            extendedController.IsBashing(true);
            anim.SetTrigger("isBashing");
        }
        else if (Input.GetKeyUp(KeyCode.Joystick1Button2) && id == 1 ||
                Input.GetKeyUp(KeyCode.Joystick2Button2) && id == 2 ||
        Input.GetKeyUp(KeyCode.Joystick3Button2) && id == 3 ||
        Input.GetKeyUp(KeyCode.Joystick4Button2) && id == 4 ||
        Input.GetKeyUp(KeyCode.Joystick5Button2) && id == 5 ||
        Input.GetKeyUp(KeyCode.Joystick6Button2) && id == 6 ||
        Input.GetKeyUp(KeyCode.Joystick7Button2) && id == 7 ||
        Input.GetKeyUp(KeyCode.Joystick8Button2) && id == 8)
        {
            extendedController.IsBashing(false);
            extendedController.ChargeBashing();
        }
    }
    void Dash(float xAxis)
    {
        #region Dash
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && id == 1 ||
            Input.GetKeyDown(KeyCode.Joystick2Button0) && id == 2 ||
            Input.GetKeyDown(KeyCode.Joystick3Button0) && id == 3 ||
            Input.GetKeyDown(KeyCode.Joystick4Button0) && id == 4 ||
            Input.GetKeyDown(KeyCode.Joystick5Button0) && id == 5 ||
            Input.GetKeyDown(KeyCode.Joystick6Button0) && id == 6 ||
            Input.GetKeyDown(KeyCode.Joystick7Button0) && id == 7 ||
            Input.GetKeyDown(KeyCode.Joystick8Button0) && id == 8)
        {
            extendedController.setTrailRenderer(true);
            extendedController.Dash(xAxis);
        }
        //on key up
        else if (Input.GetKeyUp(KeyCode.Joystick1Button0) && id == 1 ||
                Input.GetKeyUp(KeyCode.Joystick2Button0) && id == 2 ||
                Input.GetKeyUp(KeyCode.Joystick3Button0) && id == 3 ||
                Input.GetKeyUp(KeyCode.Joystick4Button0) && id == 4 ||
                Input.GetKeyUp(KeyCode.Joystick5Button0) && id == 5 ||
                Input.GetKeyUp(KeyCode.Joystick6Button0) && id == 6 ||
                Input.GetKeyUp(KeyCode.Joystick7Button0) && id == 7 ||
                Input.GetKeyUp(KeyCode.Joystick8Button0) && id == 8)
        {
            extendedController.setTrailRenderer(false);
        }
        #endregion
    }
    void Jumping()
    {
        #region jumping
        if (Input.GetKeyDown(KeyCode.Joystick1Button3) && id == 1 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick2Button3) && id == 2 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick3Button3) && id == 3 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick4Button3) && id == 4 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick5Button3) && id == 5 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick6Button3) && id == 6 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick7Button3) && id == 7 && controller.IsGrounded() ||
            Input.GetKeyDown(KeyCode.Joystick8Button3) && id == 8 && controller.IsGrounded())
        {
            controller.Jump();
            anim.SetTrigger("jump");
        }
        #endregion
    }

#endif

    void UseAbilities()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && id == 1 ||
                     Input.GetKeyDown(KeyCode.Joystick2Button1) && id == 2 ||
                     Input.GetKeyDown(KeyCode.Joystick3Button1) && id == 3 ||
                     Input.GetKeyDown(KeyCode.Joystick4Button1) && id == 4 ||
                     Input.GetKeyDown(KeyCode.Joystick5Button1) && id == 5 ||
                     Input.GetKeyDown(KeyCode.Joystick6Button1) && id == 6 ||
                     Input.GetKeyDown(KeyCode.Joystick7Button1) && id == 7 ||
                     Input.GetKeyDown(KeyCode.Joystick8Button1) && id == 8
                     )
        {


            if (hasIncSpeedAbility)
            {
                specialAbilityController.IncSpeed();
                if (onUseSpecialAbility != null) { onUseSpecialAbility(); }
            }
            else if (hasDecSpeedAbility)
            {
                specialAbilityController.DecSpeed();
                if (onUseSpecialAbility != null) { onUseSpecialAbility(); }
            }
            else if (hasReverseControllerAbility)
            {
                specialAbilityController.ReverseControl();
                if (onUseSpecialAbility != null) { onUseSpecialAbility(); }
            }
            else if (hasAttackAbility)
            {
                specialAbilityController.Attack();
                if (onUseSpecialAbility != null) { onUseSpecialAbility(); }
            }
            else if (hasDefenedAbility)
            {
                specialAbilityController.Defened();
                if (onUseSpecialAbility != null) { onUseSpecialAbility(); }
            }
        }
    }

    public void PlayerDeath()
    {
        playerHealth.Damage(1000);
        PlayerAnimator.SetTrigger("Death");
        CameraAnimator.SetTrigger("isDead");
    }
}
