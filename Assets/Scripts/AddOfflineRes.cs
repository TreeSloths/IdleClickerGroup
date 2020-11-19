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
    public long nowMinusThen;
    public int amountOfBoostFour;
    public int amountOfBoostTwo;

    private void Start()
    {
        nowMinusThen = saveTime.NowinSeconds - saveTime.Quitinseconds;
        //   Debug.Log(nowMinusThen);
        production = nowMinusThen * offlineRes;
        this.resource.ResourceAmount += Mathf.RoundToInt((float) production);
        Debug.Log($"{nowMinusThenSaveFour}");
        Debug.Log($"{nowMinusThenSaveTwo}");

        if (amountOfBoostFour >= 1)
        {
            nowMinusThenSaveFour += Convert.ToInt32(nowMinusThen);
            if (Convert.ToInt64(nowMinusThenSaveFour) <= 14400)
            {
                var boost = offlineRes * 4;
            }
        }

        if (amountOfBoostTwo >= 1)
        {
            nowMinusThenSaveTwo += Convert.ToInt32(nowMinusThen);
            if (Convert.ToInt64(nowMinusThenSaveTwo) <= 7200)
            {
                var boost = offlineRes * 2;
            }
        }
    }


    public int nowMinusThenSaveFour
    {
        get => PlayerPrefs.GetInt("MinusSaved", 0);
        set => PlayerPrefs.SetInt("MinusSaved", value);
    }

    public int nowMinusThenSaveTwo
    {
        get => PlayerPrefs.GetInt("MinusSaved", 0);
        set => PlayerPrefs.SetInt("MinusSaved", value);
    }


    public void OnBoosterClickFour()
    {
        amountOfBoostFour++;
        this.resource.ResourceAmount = -1000;
    }

    public void OnBoosterClickTwo()
    {
        amountOfBoostTwo++;
        this.resource.ResourceAmount = -700;
    }
}