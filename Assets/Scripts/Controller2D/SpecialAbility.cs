using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class SpecialAbility : MonoBehaviour
{
    StanderedController stController;
    ChickenController playerController;

    public float abilityDuration = 3f;
    public float slowSpeed = 2f;
    public float fastSpeed = 30f;
    public GameObject attckObj;
    public GameObject defenedObj;

    //bool isAttacking = false;

    bool callAbility = false;

    public Slider abilityCoolDown;
    public Image imageHolder;
    public Sprite[] images;

    //public Transform specialAbility;
    public LayerMask attackLayers;
    [HideInInspector]
    public bool isAttackerCollison = false;
    Collider2D attackedResult;


    float duration = 0;
    float xAxis;


    // Use this for initialization
    void Awake()
    {
        stController = gameObject.GetComponent<StanderedController>();
        playerController = gameObject.GetComponent<ChickenController>();

        //xAxis = Input.GetAxis(string.Format("P{0}Hori", playerController.id));
    }
    // Update is called once per frame
    void Update()
    {

        if (callAbility)
        {
            abilityCoolDown.value -= Time.deltaTime;

            if (abilityCoolDown.value <= abilityCoolDown.minValue)
            {
                //stController.currentMoveSpeed = stController.originalMoveSpeed;
                ResetPlayerValues();
                ResetAbilityBools();
                callAbility = false;
                // playerController.hasDecSpeedAbility = false;
                // xAxis = xAxis * -1;
                duration = 0;
                SelectSpecialAbilityImage(0);
            }
        }
    }

    public void IncSpeed()
    {
        ResetPlayerValues();
        callAbility = true;

        SelectSpecialAbilityImage(1);
        abilityCoolDown.value = abilityCoolDown.maxValue;

        stController.currentMoveSpeed = fastSpeed;

        ResetAbilityBools();
    }

    public void DecSpeed()
    {
        ResetPlayerValues();
        callAbility = true;
        SelectSpecialAbilityImage(2);
        abilityCoolDown.value = abilityCoolDown.maxValue;

        stController.currentMoveSpeed = slowSpeed;

        ResetAbilityBools();
    }

    public void ReverseControl()
    {
        ResetPlayerValues();
        callAbility = true;

        //SelectSpecialAbilityImage(3);
        abilityCoolDown.value = abilityCoolDown.maxValue;
        //xAxis = xAxis * -1;
        ResetAbilityBools();
    }

    public void Attack()
    {
        ResetPlayerValues();
        callAbility = true;

        SelectSpecialAbilityImage(3);
        abilityCoolDown.value = abilityCoolDown.maxValue;

        this.gameObject.layer = 13;
        attckObj.SetActive(true);

        //attackedResult = Physics2D.OverlapCircle(specialAbility.position, 0.65f, attackLayers);
        //if (attackedResult)
        //{
        //    //Debug.Log(attackLayers.value + " ,gameObjet: " + attackedResult.gameObject);
        //    if (attackLayers == LayerMask.GetMask("Crumb"))
        //    {
        //        Destroy(attackedResult.gameObject);
        //    }
        //}



        ResetAbilityBools();
    }

    public void Defened()
    {
        ResetPlayerValues();
        callAbility = true;

        SelectSpecialAbilityImage(2);
        abilityCoolDown.value = abilityCoolDown.maxValue;

        this.gameObject.layer = 13;
        defenedObj.SetActive(true);

        ResetAbilityBools();
    }

    //bool isCollidedWithSpecialAbilityLayers(LayerMask layers, float raduis = 0.65f)
    //{
    //    return (Physics2D.OverlapCircle(specialAbility.position, raduis, layers));
    //}

    void ResetAbilityBools()
    {
        playerController.hasIncSpeedAbility = false;
        playerController.hasDecSpeedAbility = false;
        playerController.hasReverseControllerAbility = false;
        playerController.hasAttackAbility = false;
        playerController.hasDefenedAbility = false;
    }

    void ResetPlayerValues()
    {

        stController.currentMoveSpeed = stController.originalMoveSpeed;
        attckObj.SetActive(false);
        defenedObj.SetActive(false);
        this.gameObject.layer = 9;
        //stController.currentJumpForce = stController.originalJumpForce; //not used yet
    }

    void SelectSpecialAbilityImage(int imageId)
    {
        imageHolder.sprite = images[imageId];
    }
}
