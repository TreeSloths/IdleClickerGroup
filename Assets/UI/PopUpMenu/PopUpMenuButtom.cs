using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopUpMenuButtom : MonoBehaviour
{
    public GameObject popUpMenu;
    public ShowWelcomeMenuOnceTracker ShowWelcomeMenuOnceTracker;
    public GameObject WelcomeMenuOnceTracker;
    public static bool hasbeenshown = false;


    public void ClosePopUp()
    {
        popUpMenu.SetActive(false);
        ShowWelcomeMenuOnceTracker.hasbeenshown = true;
    }

    public void Update()
    {
        if (ShowWelcomeMenuOnceTracker.hasbeenshown == true)
        {
            popUpMenu.SetActive(false);
        }
    }
}