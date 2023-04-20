using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class LoginHandler : MonoBehaviour
{
    public WindowHandler handler;
    public GameObject loginButton;
    bool hasAttemptedLogin = false;

    void Start()
    {
        JNIStorage.accountObj = JNIStorage.apiClass.CallStatic<AndroidJavaObject>("login", "d17a73a2-707c-40f5-8c90-d3eda0956f10");
        if (JNIStorage.accountObj != null)
        {
            loginButton.name = "Continue";
        }
    }

    public void Login()
    {
        JNIStorage.accountObj = JNIStorage.apiClass.CallStatic<AndroidJavaObject>("login", "d17a73a2-707c-40f5-8c90-d3eda0956f10");
        if (JNIStorage.accountObj != null)
        {
            handler.MainPanelSwitch();
        } else if(hasAttemptedLogin) {
            JNIStorage.apiClass.SetStatic("msaMessage", "Login failure! Ensure you have accepted the permissions then try again.");
        }
        hasAttemptedLogin = true;
    }

    void Update()
    {
        if (JNIStorage.accountObj != null)
        {
            JNIStorage.apiClass.SetStatic("msaMessage", "You can start the game now.");
            return;
        }
    }
}