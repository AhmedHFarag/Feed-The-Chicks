using UnityEngine;
using System.Collections;

public class OrignalHealthBar : MonoBehaviour
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

    public int frameWidth = 266;
    public int frameHeight = 65;

    public float offsetY = 391.97f;
    public float offsetX = 0.0f;

    public float scale=1;
    public float distance;

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

        distance = (myCamera.transform.position - transform.position).magnitude / 1.5f;

    }

    void OnGUI()
    {
        vec = myCamera.WorldToScreenPoint(transform.position);



        GUI.DrawTexture(new Rect(vec.x - (frameWidth / 2.0f) / distance,
                                 Screen.height - (vec.y + offsetY / distance * scale),
                                 frameWidth / distance*scale,
                                 frameHeight / distance * scale),
                            backgroundTexture, ScaleMode.ScaleToFit, true, 0);

        GUI.DrawTexture(new Rect(vec.x - (fixedHealthWidth / 2.0f + healthMarginLeft* scale*2) / distance ,
                                 Screen.height - (vec.y + offsetY / distance * scale) + healthMarginTop / distance * scale,
                                 healthWidth / distance * scale,
                                 healthHeight / distance * scale),
                            foregroundTexture, ScaleMode.ScaleAndCrop, true, 0);

        GUI.DrawTexture(new Rect(vec.x - (frameWidth / 2.0f) / distance,
                                 Screen.height - (vec.y + offsetY / distance * scale),
                                 frameWidth / distance * scale,
                                 frameHeight / distance * scale),
                            frameTexture, ScaleMode.ScaleToFit, true, 0);
    }
    public void TakeDamage()
    {
        GameObject obj = Instantiate(destroyEffect, transform.position, Quaternion.identity) as GameObject;
        obj.GetComponent<ParticleSystem>().Play();
        currentHealth -= 10;
        if(currentHealth<=0)
        {
            
            obj.GetComponent<ParticleSystem>().Play();
            Destroy(obj,1);
            Destroy(this.gameObject);
        }
    }
}