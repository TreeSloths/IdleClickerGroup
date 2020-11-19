using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBranch : MonoBehaviour
{
    public Resource nuts;
    public GameObject rollingSquirrel;

    public bool IsUnlocked {
        get => intToBool(PlayerPrefs.GetInt(name + "bool", 0));
        set => PlayerPrefs.SetInt(name + "bool", boolToInt(value));
    }
    

    private void Update() {
        if (IsUnlocked) {
            rollingSquirrel.SetActive(true);
        }
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
    public int price;
    
    public void BranchUnlocked()
    {
        if (nuts.ResourceAmount >= price && !IsUnlocked)
        {
            nuts.ReduceResource(price);
            rollingSquirrel.SetActive(true);
            IsUnlocked = true;
        }
    }
}
