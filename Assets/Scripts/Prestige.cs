using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prestige : MonoBehaviour {
    public Resource nuts;
    private int price = 100000;
    public SquirrelMovement groundSquirrel;
    public Storage groundStorage;
    public Nuttap tapper;
    public ClimbingSquirrel climbingSquirrel;
    
    public void PurchasePrestige() {
        if (nuts.ResourceAmount < price) {
            return;
        } else {
            PlayerPrefs.DeleteAll();
            groundSquirrel.speed += .5f;
            groundStorage.Capacity += 100;
            tapper.startingProductionAmount += 5;
            climbingSquirrel.speed += .5f;

        }
    }
}