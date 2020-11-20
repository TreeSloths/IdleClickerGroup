﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTime : MonoBehaviour
{
    public DateTime systemStart;
    public DateTime systemQuit;
    private readonly DateTime startOfTime = new DateTime(1970, 1, 1, 0, 0, 0);
    public DateTime Quittime;

    public long Quitinseconds
    {
        get { return long.Parse(timeSaveQuit); }
    }

    public long NowinSeconds
    {
        get { return Convert.ToInt64(DateTime.UtcNow.Subtract(this.startOfTime).TotalSeconds); }
    }

    private void Start()
    {
        systemStart = DateTime.Now;
//        Debug.Log($"{NowinSeconds}");
    }

    private void OnApplicationQuit()
    {
        Quittime2 = DateTime.Now.ToString();  
        var systemQuit = NowinSeconds;
        timeSaveQuit = systemQuit.ToString();
    }

    public string Quittime2
    {
        get => PlayerPrefs.GetString("QuitTimeD", "");
        set => PlayerPrefs.SetString("QuitTimeD", value);
    }
    
    public string timeSaveQuit
    {
        get => PlayerPrefs.GetString("QuitTime", NowinSeconds.ToString());
        set => PlayerPrefs.SetString("QuitTime", value);
    }
}