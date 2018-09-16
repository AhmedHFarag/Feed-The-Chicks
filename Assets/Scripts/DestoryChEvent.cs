using UnityEngine;
using System.Collections;

public class DestoryChEvent : MonoBehaviour {
    public void DestoryObject()
    {
        Destroy(this.gameObject);
    }

    public void DisabledObject()
    {
        this.gameObject.SetActive(false);
    }
}
