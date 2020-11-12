using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour {
   // public Text AmountDisplay;
    public int currentBucketAmount;
    public int capacity = 50;
    public bool hasCapacity;

    private void Update() {
      //  AmountDisplay.transform.position = this.transform.position + new Vector3(0,5,0);
    }

    public void AddAmount(int amount) {
        if (amount <= 0) {
            currentBucketAmount += amount;
          //  UpdateDisplay();
        }
    }

    public void ReduceAmount(int amount) {
        if (currentBucketAmount >= amount) {
            currentBucketAmount -= amount;
          //  UpdateDisplay();
        }
    }

    // //public void UpdateDisplay() {
    //     AmountDisplay.text = currentBucketAmount.ToString ("C0");
    // }
}