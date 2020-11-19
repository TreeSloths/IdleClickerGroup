using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour {

    
    public bool hasCapacity;

    public bool HasSpace => CurrentAmount < Capacity;

    
    public int Capacity {
        get => PlayerPrefs.GetInt(name+"capacity",10);
        set => PlayerPrefs.SetInt(name+"capacity",value);
    }
    public int CurrentAmount {
        get => PlayerPrefs.GetInt(name+"currentAmount",0);
        set { PlayerPrefs.SetInt(name + "currentAmount", value); }
    }

    private void Update() {
     
    }

    public void AddAmount(int amount) {
        if (amount <= 0) {
            CurrentAmount += amount;
        }
    }

    public void ReduceAmount(int amount) {
        if (CurrentAmount >= amount) {
            CurrentAmount -= amount;
        }
    }
    
}