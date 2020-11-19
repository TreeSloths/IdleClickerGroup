using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOfflineRes : MonoBehaviour
{
    public SaveTime SaveTime;
    public Resource Resource;
    public float offlineRes;
    public float addingResToTime;
    public float addOfflineRes;
    public double production;

    private void Start()
    {
        var _nowMinusThen = SaveTime.NowinSeconds - SaveTime.Quitinseconds;
        Debug.Log(_nowMinusThen);
        // DO NOT INSERT ANYTHING IN addingResToTime
        production = _nowMinusThen * offlineRes;
        this.Resource.ResourceAmount += Mathf.RoundToInt((float) production);
        // LÄGG TILL NUTS SCRIPT OCH LÄGG TILL PLAYERPREFS NUTS HAND I HAND MED SEKUNDERNA
    }
}