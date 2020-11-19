using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTime : MonoBehaviour
{
    public DateTime systemStart;
    public DateTime systemQuit;
    private readonly DateTime startOfTime = new DateTime(1970, 1, 1, 0, 0, 0);

    public long Quitinseconds
    {
        get
        {
            DateTime converting = Convert.ToDateTime(timeSaveQuit);
            return Convert.ToInt64(converting.Subtract(this.startOfTime).TotalSeconds);
        }
    }
    
    public long NowinSeconds {
        get {
            return Convert.ToInt64(DateTime.UtcNow.Subtract(this.startOfTime).TotalSeconds);
        }
    }

    private void Start()
    {
        systemStart = DateTime.Now;
       // Debug.Log($"{NowinSeconds}");
    }

    private void OnApplicationQuit()
    {
        systemQuit = DateTime.Now;
        timeSaveQuit = systemQuit.ToString();
    }

    public string timeSaveQuit
    {
        get => PlayerPrefs.GetString("QuitTime", "");
        set => PlayerPrefs.SetString("QuitTime", value);
    }
}