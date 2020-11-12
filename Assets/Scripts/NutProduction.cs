using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutProduction : MonoBehaviour
{
    public float nutProductiontime;
    private float _elapsedTime;
    private float _systemTime;
    private float _systemTimeQuit;


    private void Start()
    {
        _systemTime = Convert.ToSingle(System.DateTime.Now);
        timeSaveStart = _systemTime;
    }

    private void OnApplicationQuit()
    {
        _systemTimeQuit = Convert.ToSingle(System.DateTime.Now);
        timeSaveQuit = _systemTimeQuit;
    }

    public float timeSaveQuit
    {
        get => PlayerPrefs.GetFloat("QuitTime", 0);
        set => PlayerPrefs.SetFloat("QuitTime", value);
    }

    public float timeSaveStart
    {
        get => PlayerPrefs.GetFloat("StartTime", 0);
        set => PlayerPrefs.SetFloat("StartTime", value);
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