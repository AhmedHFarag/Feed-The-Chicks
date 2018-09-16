﻿using UnityEngine;
using System.Collections;

public class IntroCrumbBehavoiur : MonoBehaviour
{
    public delegate void crumbEventHandler();

    public static event crumbEventHandler onPlayerEatOrdenaryCrumb;
    public static event crumbEventHandler onPlayerEatCrumbWithAbility;

    //public static void playerEatCrumb()
    //{
    //    onPlayerEat();
    //}

    //public GameObject obj;
    //public float duration = 5;
    ParticleSystem ParticleComponent;

    specialAbilities ability = new specialAbilities();
    PopUpSpecialAbility popUpAbility;

    //popupSpecialImage
    public GameObject popupAbilityObject;
    public float popupDouration = 2;
    public float raiseSpeed = 2;

    //public Sprite[] abilityImages;

    [SerializeField]
    bool hasAbility;

    float t = 0;

    public Sprite[] specialImages;
    public float disableTime = 40f; //time needed to disable the crumbs
    public float amountOfFeed = 10f;
    float counter = 0; //counter to disable the crumbs
    
    void Awake()
    {
        popUpAbility = popupAbilityObject.GetComponent<PopUpSpecialAbility>();

        //ParticleComponent = transform.GetChild(1).GetComponent<ParticleSystem>();
        //ParticleComponent.enableEmission = false;
    }
    void Update()
    {
        //DisableCrumb(disableTime);
    }

    void OnCollisionEnter2D(Collision2D info)
    {
        if (info.gameObject.layer == 9 || info.gameObject.layer == 13)
        {
            Healthbar PlayerHealth = info.gameObject.GetComponent<Healthbar>();

            this.gameObject.SetActive(false);
            PlayerHealth.IncreaseHealth(amountOfFeed);
            if (onPlayerEatOrdenaryCrumb != null) { onPlayerEatOrdenaryCrumb(); }

            //decHealth.GetComponent<Animator>().SetTrigger("RemoveDecreaseHelthPanel");
            //incHealth.GetComponent<Animator>().enabled = true;

            if (hasAbility)
            {
                if (onPlayerEatCrumbWithAbility != null) { onPlayerEatCrumbWithAbility(); }

                GameObject specialAbilityParticals = info.transform.GetChild(1).gameObject;

                GameObject popupAbilityImage = GameObject.Instantiate(popupAbilityObject);
                popupAbilityImage.transform.parent = info.transform;
                popupAbilityImage.transform.position = info.transform.position;

                specialAbilityParticals.SetActive(false);
                specialAbilityParticals.SetActive(true);
                // Debug.Log(specialAbilityParticals.GetComponent<ParticleSystem>().playbackSpeed);
                //specialAbilityParticals.GetComponent<ParticleSystem>().playbackSpeed = 4;
                //specialAbilityParticals.GetComponent<ParticleSystem>().Simulate(0);  
                //ParticleSystem.simulate 
                specialAbilities random = (specialAbilities)Random.Range(0, 3);
                //random = (specialAbilities)3;
                switch (random)
                {
                    case specialAbilities.incSpeed:
                        info.gameObject.GetComponent<IntroChicksController>().hasIncSpeedAbility = true;
                        //popupAbilityObject
                        popupAbilityImage.GetComponent<PopUpSpecialAbility>().setup(specialImages[(int)specialAbilities.incSpeed], popupDouration, raiseSpeed);
                        break;
                    case specialAbilities.decSpeed://ability.decSpeed
                        info.gameObject.GetComponent<IntroChicksController>().hasDecSpeedAbility = true;
                        popupAbilityImage.GetComponent<PopUpSpecialAbility>().setup(specialImages[(int)specialAbilities.decSpeed], popupDouration, raiseSpeed);
                        break;
                    case specialAbilities.reverseControl://ability.reverseControl
                        info.gameObject.GetComponent<IntroChicksController>().hasReverseControllerAbility = true;
                        popupAbilityImage.GetComponent<PopUpSpecialAbility>().setup(specialImages[(int)specialAbilities.reverseControl], popupDouration, raiseSpeed);
                        break;
                    case specialAbilities.attack:
                        info.gameObject.GetComponent<IntroChicksController>().hasAttackAbility = true;
                        //Debug.Log((int)specialAbilities.attack + "->" + specialImages.Length);
                        popupAbilityImage.GetComponent<PopUpSpecialAbility>().setup(specialImages[(int)specialAbilities.attack], popupDouration, raiseSpeed);
                        break;
                    case specialAbilities.Defened:
                        info.gameObject.GetComponent<IntroChicksController>().hasDefenedAbility = true;
                        //Debug.Log((int)specialAbilities.attack + "->" + specialImages.Length);
                        popupAbilityImage.GetComponent<PopUpSpecialAbility>().setup(specialImages[(int)specialAbilities.Defened], popupDouration, raiseSpeed);
                        break;
                    default:
                        break;
                }
            }
        }
        else if (info.gameObject.tag == "PlayArea")
        {
            this.gameObject.SetActive(false);
        }
        else if (info.gameObject.layer == 8) // collide with ground
        {
            //ParticleComponent.enableEmission = true;
        }
    }

    void DisableCrumb(float disableTime)
    {
        counter += .05f;//Time.deltaTime;
        if (counter >= disableTime)
        {
            this.gameObject.SetActive(false);
            counter -= disableTime;
        }
    }
}