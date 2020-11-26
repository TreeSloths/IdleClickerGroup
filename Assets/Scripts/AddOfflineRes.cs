using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AddOfflineRes : MonoBehaviour
{
    public SaveTime saveTime;
    public Resource resource;
    public float offlineRes = 0.6f;

    private void Start()
    {
        double _nowMinusThen = saveTime.NowinSeconds - saveTime.Quitinseconds;
        Debug.Log($"{_nowMinusThen}");
        resource.production = _nowMinusThen * offlineRes;
        Debug.Log(+resource.production);
        this.resource.ResourceAmount += Mathf.RoundToInt((float) resource.production);
        Debug.Log(+this.resource.ResourceAmount);
    }
    
}