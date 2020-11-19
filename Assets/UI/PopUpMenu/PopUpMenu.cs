﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMenu : MonoBehaviour
{
    public Text popUpMenuText;
    public Text popupMenuRes;
    public SaveTime SaveTime;
    public AddOfflineRes AddOfflineRes;
    private DateTime displayTime;

    void Start()
    {
        this.popUpMenuText.text = $"Welcome back, this is the time you were last online: {SaveTime.systemStart}";
        this.popupMenuRes.text =
            $"This is the amount of resources you have harvested while you were offline: {AddOfflineRes.production}";
    }

    
}