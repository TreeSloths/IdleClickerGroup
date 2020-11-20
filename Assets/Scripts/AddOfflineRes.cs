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

    private void Start()
    {
        nowMinusThen = saveTime.NowinSeconds - saveTime.Quitinseconds;
        if (AmountofBoostsFour == 0 && AmountofBoostsTwo == 0)
        {
            production = nowMinusThen * offlineRes;
            this.resource.ResourceAmount += Mathf.RoundToInt((float) production);
        }
        else
        {
            return;
        }

        Debug.Log($"{nowMinusThenSaveFour}");
        Debug.Log($"{nowMinusThenSaveTwo}");

        if (AmountofBoostsFour >= 1)
        {
            nowMinusThenSaveFour += Convert.ToInt32(nowMinusThen);
            if (Convert.ToInt64(nowMinusThenSaveFour) <= 14400)
            {
                production = nowMinusThen * offlineRes * 4;
                this.resource.ResourceAmount += Mathf.RoundToInt((float) production);
            }
            else if (Convert.ToInt64(nowMinusThenSaveFour) >= 14400)
            {
                AmountofBoostsFour--;
            }
        }

        if (AmountofBoostsTwo >= 1)
        {
            nowMinusThenSaveTwo += Convert.ToInt32(nowMinusThen);
            if (Convert.ToInt64(nowMinusThenSaveTwo) <= 7200)
            {
                production = nowMinusThen * offlineRes * 2;
                this.resource.ResourceAmount += Mathf.RoundToInt((float) production);
            }
        }
        else if (Convert.ToInt64(nowMinusThenSaveTwo) >= 7200)
        {
            AmountofBoostsTwo--;
        }
    }

    public int AmountofBoostsFour
    {
        get => PlayerPrefs.GetInt("FourHourBoostsSaved", 0);
        set => PlayerPrefs.SetInt("FourHourBoostsSaved", value);
    }

    public int AmountofBoostsTwo
    {
        get => PlayerPrefs.GetInt("TwoHoursBoostsSaved", 0);
        set => PlayerPrefs.SetInt("TwoHoursBoostsSaved", value);
    }


    public int nowMinusThenSaveFour
    {
        get => PlayerPrefs.GetInt("MinusSavedForFourHoursBoosts", 0);
        set => PlayerPrefs.SetInt("MinusSavedForFourHoursBoosts", value);
    }

    public int nowMinusThenSaveTwo
    {
        get => PlayerPrefs.GetInt("MinusSavedForTwoHoursBoosts", 0);
        set => PlayerPrefs.SetInt("MinusSavedForTwoHoursBoosts", value);
    }


    public void OnBoosterClickFour()
    {
        if (resource.ResourceAmount >= 1000)
        {
            this.resource.ResourceAmount -= 1000;
            AmountofBoostsFour++;
        }
    }

    public void OnBoosterClickTwo()
    {
        if (resource.ResourceAmount >= 1000)
        {
            this.resource.ResourceAmount -= 1000;
            AmountofBoostsTwo++;
        }
    }
}