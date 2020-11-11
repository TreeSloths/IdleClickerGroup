using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Resource : ScriptableObject {
    
    public int ResourceAmount {
        get => PlayerPrefs.GetInt(name, 0);
        set => PlayerPrefs.SetInt(name, value);
    }
    
    
    public void AddResource(int addAmount) {
        if (addAmount > 0)
            ResourceAmount += addAmount;
    }

    public void ReduceResource(int reduceBy) {
        if (ResourceAmount < reduceBy) {
            return;
        } else ResourceAmount -= reduceBy;
    }
}