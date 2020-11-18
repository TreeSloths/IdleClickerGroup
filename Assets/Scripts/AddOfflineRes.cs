using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOfflineRes : MonoBehaviour
{
    public SaveTime SaveTime;
    public float offlineRes;
    public float addingResToTime;

    private void Start()
    {
        var _nowMinusThen = SaveTime.Quitinseconds - SaveTime.NowinSeconds;
        Debug.Log(_nowMinusThen);
        // DO NOT INSERT ANYTHING IN addingResToTime
        addingResToTime = _nowMinusThen * offlineRes;
    }
}