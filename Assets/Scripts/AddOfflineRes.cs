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

    private void Start()
    {
        var _nowMinusThen = SaveTime.Quitinseconds - SaveTime.NowinSeconds;
        Debug.Log(_nowMinusThen);
        // DO NOT INSERT ANYTHING IN addingResToTime
        for (int i = 0; i < _nowMinusThen; i++)
        {
            var production = this.Resource.ResourceAmount * offlineRes;
        }


        // LÄGG TILL NUTS SCRIPT OCH LÄGG TILL PLAYERPREFS NUTS HAND I HAND MED SEKUNDERNA
    }
}