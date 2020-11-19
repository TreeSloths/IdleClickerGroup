using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOfflineRes : MonoBehaviour
{
    public SaveTime SaveTime;
    public Resource Resource;
    public float offlineRes = 0.6f;
    public double production;
    public long nowMinusThen;

    private void Start()
    {
        nowMinusThen = SaveTime.NowinSeconds - SaveTime.Quitinseconds;
        Debug.Log(nowMinusThen);
        production = nowMinusThen * offlineRes;
        this.Resource.ResourceAmount += Mathf.RoundToInt((float) production);
        nowMinusThenSave = nowMinusThen.ToString();
    }
    
    public string nowMinusThenSave
    {
        get => PlayerPrefs.GetString("MinusSaved", "");
        set => PlayerPrefs.SetString("MinusSaved", value);
    }
    
    private void boostFourHours()
    {
        while (Convert.ToInt64(nowMinusThenSave) != 14400)
        {
            var boost = offlineRes * 4;
        }
    }
    
}