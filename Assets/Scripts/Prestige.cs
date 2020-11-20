using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prestige : MonoBehaviour {
    public Resource nuts;
    private int price = 100000;
    public Nuttap tapper;

    public void PurchasePrestige() {
        if (nuts.ResourceAmount < price) {
            return;
        } else {
            PlayerPrefs.DeleteAll();
            tapper.startingProductionAmount += 100;
        }
    }
}