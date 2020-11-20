﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOfflineRes : MonoBehaviour
{
    public SaveTime SaveTime;
    public Resource Resource;
    public float offlineRes = 0.6f;
    public double production;
    public double nowMinusThen;
    private void Start()
    {
        nowMinusThen = SaveTime.NowinSeconds - SaveTime.Quitinseconds;
        Debug.Log($"{nowMinusThen}");
        production = nowMinusThen * offlineRes;
        this.Resource.ResourceAmount += Mathf.RoundToInt((float) production);
    }
}