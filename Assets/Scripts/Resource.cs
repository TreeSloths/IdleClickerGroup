using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Resource : ScriptableObject {

    public double ResourceAmount {
        get => PlayerPrefs.GetInt(name, 0);
        set => PlayerPrefs.(name, value);
    }
    
    
    public void AddResource(double addAmount) {
        if (addAmount > 0)
            ResourceAmount += addAmount;
    }

    public void ReduceResource(double reduceBy) {
        if (ResourceAmount < reduceBy) {
            return;
        } else ResourceAmount -= reduceBy;
    }
}