using UnityEngine;
using System.Collections;

public class BlockDeath : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Disable();
    }
    void Disable()
    {
        if (this.transform.position.y <= -5)
        {
            this.gameObject.SetActive(false);// = false;
        }
    }
}
