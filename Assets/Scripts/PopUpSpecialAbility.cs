using UnityEngine;
using System.Collections;


public class PopUpSpecialAbility : MonoBehaviour
{
    //public Sprite[] SpecialImages;
    // private variables:
    Vector3 crds_delta;
    float alpha;
    float life_loss;
    Camera cam;
    RectTransform rectTrans;

    // public variables - you can change this in Inspector if you need to
    public Color color = Color.white;

    // SETUP - call this once after having created the object, to make it 
    // "points" shows the points.
    // "duration" is the lifespan of the object
    // "rise speed" is how fast it will rise over time.
    public void setup(Sprite image, float duration, float rise_speed)
    {
        GetComponent<SpriteRenderer>().sprite = image;
        life_loss = 1f / duration;
        crds_delta = new Vector3(0f, rise_speed, 0f);
    }

    void Start() // some default values. You still need to call "setup"
    {
        rectTrans = GetComponent<RectTransform>();
        alpha = 1f;
        cam = Camera.main;
        crds_delta = new Vector3(0f, 1f, 0f);
        life_loss = 0.5f;
    }

    void Update()
    {
        // move upwards :
        transform.Translate(crds_delta * Time.deltaTime, Space.World);

        // change alpha :
        alpha -= Time.deltaTime * life_loss;
        gameObject.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, alpha);

        // if completely faded out, die:
        if (alpha <= 0f) Destroy(gameObject);

        //increase size
        rectTrans.localScale += new Vector3(0.002f, 0.002f, 0);

        // make it face the camera:
        transform.LookAt(cam.transform.position);
        transform.rotation = cam.transform.rotation;
    }
}
