using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{

    public Camera myCamera;
    public Vector3 vec;

    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public GameObject destroyEffect;
    public Texture backgroundTexture;
    public Texture foregroundTexture;
    public Texture frameTexture;

    public int fixedHealthWidth = 197;
    float healthWidth;
    public int healthHeight = 28;

    public int healthMarginLeft = -28;
    public int healthMarginTop = 25;

    public int frameWidth = 1920;
    public int frameHeight = 1080;

    public float offsetY = 391.97f;
    public float offsetX = 0.0f;

    public float scale = 1;
    public float distance;

    public Transform barPosition;


    // Use this for initialization
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthWidth = fixedHealthWidth * (currentHealth / maxHealth);

        //distance =   (myCamera.transform.position - transform.position).magnitude / 1.5f;

    }

    void OnGUI()
    {
       // vec = myCamera.WorldToScreenPoint(transform.position);



        GUI.DrawTexture(new Rect(barPosition.position.x,
                                 barPosition.position.y,
                                 frameWidth  *scale/ 8 ,
                                 frameHeight * scale / 8),
                            backgroundTexture, ScaleMode.ScaleToFit, true, 0);

        GUI.DrawTexture(new Rect(barPosition.position.x - offsetX,/*+healthMarginLeft */
                                 barPosition.position.y - offsetY,/*+ offsetY  + healthMarginTop*/
                                 healthWidth * scale / 8,
                                 healthHeight * scale / 8),
                            foregroundTexture, ScaleMode.ScaleAndCrop, true, 0);

        GUI.DrawTexture(new Rect(barPosition.position.x,
                                 barPosition.position.y,
                                 frameWidth * scale / 8,
                                 frameHeight * scale / 8),
                            frameTexture, ScaleMode.ScaleToFit, true, 0);
    }
    public void TakeDamage()
    {
        GameObject obj = Instantiate(destroyEffect, transform.position, Quaternion.identity) as GameObject;
        obj.GetComponent<ParticleSystem>().Play();
        currentHealth -= 10;
        if (currentHealth <= 0)
        {

            obj.GetComponent<ParticleSystem>().Play();
            Destroy(obj, 1);
            Destroy(this.gameObject);
        }
    }
}
