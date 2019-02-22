using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire2 : MonoBehaviour {
    firebase fb;

	// Use this for initialization
	void Start () {
        
	}

    public void execute() {
        fb = GetComponent<firebase>();
        fb.InitializeFirebase();

    }

}
