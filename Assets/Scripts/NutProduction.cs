using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutProduction : MonoBehaviour
{
    public float nutProductiontime;
    private float _elapsedTime;
    private string _startTime;
    private string _systemTimeQuit;


    private void Start()
    {
        _startTime = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        Debug.Log($"{_startTime}");
    }

    private void OnApplicationQuit()
    {
        _systemTimeQuit = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        timeSaveQuit = _systemTimeQuit;
    }

    public string timeSaveQuit
    {
        get => PlayerPrefs.GetString("QuitTime", "");
        set => PlayerPrefs.SetString("QuitTime", value);
    }
    
    void Update()
    {
    }

    public void nutProduction()
    {
        if (this._elapsedTime >= nutProductiontime)
        {
            return;
            this._elapsedTime -= this.nutProductiontime;
        }
        else
        {
            return;
        }
    }
}