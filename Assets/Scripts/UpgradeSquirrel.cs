using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSquirrel : MonoBehaviour {
    private SquirrelMovement squirrel;
    public Resource nuts;
    public int price;
    public float priceMultiplier = 1.1f;
    public float speedModifier;
    

    private void Start() {
        squirrel = GetComponent<SquirrelMovement>();
        
        
    }
}