﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWelcomeMenuOnceTracker : MonoBehaviour
{
    public PopUpMenuButtom PopUpMenuButtom;
    public GameObject popUpMenu;

    private void Start()
    {
        if (ShowWelcomeOnce == 0)
        {
            popUpMenu.SetActive(true);
        }
        else if (ShowWelcomeOnce == 1)
        {
            popUpMenu.SetActive(false);
        }
    }


    public int ShowWelcomeOnce
    {
        get => PlayerPrefs.GetInt("FalseOrActiveV", 0);
        set => PlayerPrefs.SetInt("FalseOrActive", value);
    }

    private void OnApplicationQuit()
    {
        ShowWelcomeOnce = 0;
    }
}