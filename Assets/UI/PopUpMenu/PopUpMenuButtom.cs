using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopUpMenuButtom : MonoBehaviour
{
    public GameObject popUpMenu;
    public PopUpMenu PopUpMenu;
    public ShowWelcomeMenuOnceTracker ShowWelcomeMenuOnceTracker;

    public void ClosePopUp()
    {
        popUpMenu.SetActive(false);
        ShowWelcomeMenuOnceTracker.ShowWelcomeOnce++;
    }
}