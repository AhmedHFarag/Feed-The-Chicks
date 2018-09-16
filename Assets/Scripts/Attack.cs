using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
     ExtentedFeatures extendedController;
    // Use this for initialization
    void Awake()
    {
        extendedController = transform.parent.GetComponent<ExtentedFeatures>();
    }

    void OnCollisionEnter2D(Collision2D info)
    {
        if (info.gameObject.layer == 9)
        {
            extendedController.Bash(info);
        }
    }
}
