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
    public int amountOfBoostFour;

    private void Start()
    {
        nowMinusThen = SaveTime.NowinSeconds - SaveTime.Quitinseconds;
        //   Debug.Log(nowMinusThen);
        production = nowMinusThen * offlineRes;
        this.Resource.ResourceAmount += Mathf.RoundToInt((float) production);
        Debug.Log($"{nowMinusThenSave}");
        nowMinusThenSave += Convert.ToInt32(nowMinusThen);
    }

    private void OnApplicationQuit()
    {
        
    }

    public int nowMinusThenSave
    {
        get => PlayerPrefs.GetInt("MinusSaved", 0);
        set => PlayerPrefs.SetInt("MinusSaved", value);
    }


    public void OnBoosterClickFour()
    {
        amountOfBoostFour++;
    }


    public void boostFourHours()
    {
        if (Convert.ToInt64(nowMinusThenSave) <= 14400)
        {
            var boost = offlineRes * 4;
        }
    }

    public void boostTwoHours()
    {
        if (Convert.ToInt64(nowMinusThenSave) <= 7200)
        {
            var boost = offlineRes * 2;
        }
    }
}