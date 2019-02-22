using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
public class auth : MonoBehaviour {

    FirebaseAuth auths;
	// Use this for initialization
	void Start () {
        auths = Firebase.Auth.FirebaseAuth.DefaultInstance;


    }

    public void newUser() {
        auths.CreateUserWithEmailAndPasswordAsync("pasinduyyyyy@gmail.com", "abce1234Abc").ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });




    }


    // Update is called once per frame
    void Update () {
		
	}
}
