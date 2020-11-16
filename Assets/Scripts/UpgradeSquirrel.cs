using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSquirrel : MonoBehaviour {
    private SquirrelMovement squirrel;
    public Resource nuts;
    public int price = 400;
    public float priceMultiplier = 5f;
    public float speedModifier = 1.1f;
    public int level = 0;
    public Storage storage;
    public TransferStorage transfer;
    

    private void Start() {
        squirrel = GetComponent<SquirrelMovement>();
        storage = squirrel.GetComponent<Storage>();
        transfer = squirrel.GetComponent<TransferStorage>();
    }

    private void Update() {
        
    }

    public void PurchaseUpgrade() {
        if (nuts.ResourceAmount < price) {
            return;
        } else {
            nuts.ReduceResource(price);
            squirrel.speed *= speedModifier;
            storage.capacity += 50;
            transfer.waitTimer -= 0.2f;
            price *= Mathf.RoundToInt(priceMultiplier);
            level++;
            
        }
    }
}
