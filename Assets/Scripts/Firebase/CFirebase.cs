using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFirebase : MonoBehaviour
{
    DatabaseReference m_Reference;
    string userID = "wkddpdnjs99";

    // Start is called before the first frame update
    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        ReadUserData();
    }

    // Update is called once per frame
    private void ReadUserData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    string userID = "wkddpdnjs99";

                    // Do something with snapshot...
                    //Debug.Log(snapshot.Child(userID).Child("animals").Child("0").Child("name").Value);

                }
            });
    }

    void WriteUserData(string userId, string username)
    {
        m_Reference.Child("users").Child(userId).Child("username").SetValueAsync(username);
    }
}
