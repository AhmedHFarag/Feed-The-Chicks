using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }
}
