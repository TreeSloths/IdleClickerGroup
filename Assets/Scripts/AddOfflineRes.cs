using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOfflineRes : MonoBehaviour
{
    public SaveTime SaveTime;
    public Resource Resource;
    public float offlineRes = 0.6f;
    public float addingResToTime;
    public float addOfflineRes;
    public double production;
    public long nowMinusThen;
    private void Start()
    {
        nowMinusThen = SaveTime.NowinSeconds - SaveTime.Quitinseconds;
        Debug.Log(nowMinusThen);
        // DO NOT INSERT ANYTHING IN addingResToTime
        production = nowMinusThen * offlineRes;
        this.Resource.ResourceAmount += Mathf.RoundToInt((float) production);
    }
}