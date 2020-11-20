using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOfflineRes : MonoBehaviour
{
    public SaveTime saveTime;
    public Resource resource;
    public float offlineRes = 0.6f;
    public double production;
    private double _nowMinusThen;

    private void Start()
    {
        _nowMinusThen = saveTime.NowinSeconds - saveTime.Quitinseconds;
        
        production = _nowMinusThen * offlineRes;
        this.resource.ResourceAmount += Mathf.RoundToInt((float) production);
    }
}