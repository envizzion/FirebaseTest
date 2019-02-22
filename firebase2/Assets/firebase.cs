using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;

public class firebase : MonoBehaviour
{

    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    public InputField txt;

    void Start()
    {
        dependencyStatus = FirebaseApp.CheckDependencies();
        if (dependencyStatus != DependencyStatus.Available)
        {
            FirebaseApp.FixDependenciesAsync().ContinueWith(task => {
                dependencyStatus = FirebaseApp.CheckDependencies();
                if (dependencyStatus == DependencyStatus.Available)
                {
                    InitializeFirebase();
                }
                else
                {
                    Debug.LogError(
                        "Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
        }
        else
        {
           // InitializeFirebase();

        }
    }

    public void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://vrcycling-6cab8.firebaseio.com/");
        if (app.Options.DatabaseUrl != null)
        {
 
            app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
            Debug.Log("Initialized Success");

            writeNewUser(txt.text, "chanon", "taforyou@hotmail.com");

        }

    }

    public void writeNewUser(string userId, string name, string email)
    {

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        User user = new User(name, email);
        string json = JsonUtility.ToJson(user);

        reference.Child("user").Child(userId).SetRawJsonValueAsync(json);
    }

}

public class User
{
    public string username;
    public string email;

    public User()
    {
    }

    public User(string username, string email)
    {
        this.username = username;
        this.email = email;
    }
}