using UnityEngine;
using System.Collections;

public class DestroyFeather : MonoBehaviour {

    public float destoryTime = 3;

	// Use this for initialization
	void Start () {
        GameObject.Destroy(this.gameObject, destoryTime);
	}
}
