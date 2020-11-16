using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour {

    public int currentAmount;
    public int capacity = 50;
    public bool hasCapacity;

    public bool HasSpace => currentAmount < capacity;

    private void Update() {
     
    }

    public void AddAmount(int amount) {
        if (amount <= 0) {
            currentAmount += amount;
        }
    }

    public void ReduceAmount(int amount) {
        if (currentAmount >= amount) {
            currentAmount -= amount;
        }
    }
    
}