using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroExtendedFeature : MonoBehaviour
{
    public delegate void ExtendedFeature();
    public static event ExtendedFeature OnBashing;
    public static event ExtendedFeature OnBashingEnd;


    public AudioSource bashSound;
    Rigidbody2D Player;
    TrailRenderer trailRenderer;

    public float dashForce = 15;

    public float amoutOfBashing = 20; //amout of decreasing healthof otherPlayer;
    public float bashingPower = 2000; //power of impulse

    public Slider bashCoolDownSlider;
    public float amountOfCharge = 0.1f;
    // public float bashingcoolDownTime = 100f; //time betwwen each bashing;

    bool isBashing = false;
    float bashingDirection = 0;

    public GameObject Feather;
    public float featherPlayBackSpeed = 4;

    public GameObject popupScore;
    public float popupDouration = 2;
    public float raiseSpeed = 2;

    void Awake()
    {
        Player = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        // bashCoolDownSlider.maxValue = bashingcoolDownTime;
    }

    public void Dash(float Axis)
    {
        trailRenderer.enabled = true;
        Player.AddForce(new Vector2(Axis, 0) * dashForce, ForceMode2D.Impulse);
    }

    public void setTrailRenderer(bool value)
    {
        trailRenderer.enabled = value;
    }

    public void IsBashing(bool value)
    {
        isBashing = value;
    }

    public bool ChargeBashing()
    {
        bool canBash = false;
        bashCoolDownSlider.value -= amountOfCharge;
        if (bashCoolDownSlider.value <= bashCoolDownSlider.minValue)
        {
           
            canBash = true;
        }
        return canBash;
    }

    void OnCollisionStay2D(Collision2D info)
    {
        //bashingcoolDownTime += Time.deltaTime;

        if (info.gameObject.layer == 9 && isBashing && bashCoolDownSlider.value == bashCoolDownSlider.minValue)//)&& bashingcoolDownTime >= 5)
        {
            Bash(info);
            //    bashSound.Play();
            //    bashingDirection = (info.transform.position.x - this.transform.position.x);
            //    Healthbar enemyHealth = info.gameObject.GetComponent<Healthbar>();
            //    Rigidbody2D enemyRigidBody = info.gameObject.GetComponent<Rigidbody2D>();
            //    GameObject enemyExtentedFeaturesFeather = info.gameObject.GetComponent<ExtentedFeatures>().Feather;

            //    ChickenController enemyController = info.gameObject.GetComponent<ChickenController>();


            //    enemyHealth.Damage(amoutOfBashing);//currentHealth -= amoutOfBashing;
            //    //enemyRigidBody.AddForce(new Vector2(Mathf.Sign(bashingDirection) * bashingPower, 0), ForceMode2D.Force);
            //    enemyRigidBody.AddForce(new Vector2(Mathf.Sign(bashingDirection) * bashingPower, 5), ForceMode2D.Force);

            //    GameObject enemyFeather = GameObject.Instantiate(enemyExtentedFeaturesFeather);
            //    enemyFeather.transform.position = info.transform.position;
            //    enemyFeather.transform.parent = info.transform;
            //   // enemyFeather.GetComponent<ParticleSystem>().playbackSpeed = featherPlayBackSpeed;

            //    GameObject popupText = GameObject.Instantiate(popupScore);
            //    popupText.transform.parent = info.transform;
            //    popupText.transform.position = info.transform.position;

            //    popupText.GetComponent<PopUpScore>().setup((int)amoutOfBashing, popupDouration, raiseSpeed);
            //    popupText.GetComponent<PopUpScore>().color = enemyController.chickColor;
            //    bashCoolDownSlider.value = bashCoolDownSlider.maxValue;
            //    //bashingcoolDownTime = 0;
        }
    }

    public void Bash(Collision2D info)
    {
        if (OnBashing != null) { OnBashing(); }
        bashSound.Play();
        bashingDirection = (info.transform.position.x - this.transform.position.x);
        //Healthbar enemyHealth = info.gameObject.GetComponent<Healthbar>();
        Rigidbody2D enemyRigidBody = info.gameObject.GetComponent<Rigidbody2D>();
        GameObject enemyExtentedFeaturesFeather = info.gameObject.GetComponent<ExtentedFeatures>().Feather;

        //IntroChicksController enemyController = info.gameObject.GetComponent<IntroChicksController>();


        //enemyHealth.Damage(amoutOfBashing);//currentHealth -= amoutOfBashing;
                                           //enemyRigidBody.AddForce(new Vector2(Mathf.Sign(bashingDirection) * bashingPower, 0), ForceMode2D.Force);
        enemyRigidBody.AddForce(new Vector2(Mathf.Sign(bashingDirection) * bashingPower, 5), ForceMode2D.Force);

        GameObject enemyFeather = GameObject.Instantiate(enemyExtentedFeaturesFeather);
        enemyFeather.transform.position = info.transform.position;
        enemyFeather.transform.parent = info.transform;
        // enemyFeather.GetComponent<ParticleSystem>().playbackSpeed = featherPlayBackSpeed;

        GameObject popupText = GameObject.Instantiate(popupScore);
        popupText.transform.parent = info.transform;
        popupText.transform.position = info.transform.position;

        popupText.GetComponent<PopUpScore>().setup((int)amoutOfBashing, popupDouration, raiseSpeed);
        popupText.GetComponent<PopUpScore>().color = Color.blue;// enemyController.chickColor;
        bashCoolDownSlider.value = bashCoolDownSlider.maxValue;
        //bashingcoolDownTime = 0;
    }
}
