using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWelcomeMenuOnceTracker : MonoBehaviour
{
    public GameObject popUpMenu;
    public GameObject WelcomeScreenTracker;
    public static bool hasbeenshown = false;


    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
}