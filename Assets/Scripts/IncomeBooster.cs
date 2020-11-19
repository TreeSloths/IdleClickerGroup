using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeBooster : MonoBehaviour {
    public TransferStorage groundSquirrel;
    public Resource nuts;
    public int price;
    private bool isBoosting;

    IEnumerator Boosted() {
        yield return new WaitForSeconds(300);
        groundSquirrel.isBoosted10 = false;
        isBoosting = false;
    }
    IEnumerator Boosted8() {
        yield return new WaitForSeconds(600);
        groundSquirrel.isBoosted5 = false;
        isBoosting = false;
    }

    public void PurchaseBoost10x5min() {
        if (nuts.ResourceAmount >= price && !isBoosting) {
            nuts.ReduceResource(price);
            StartCoroutine(Boosted());
            groundSquirrel.isBoosted10 = true;
            isBoosting = true;
        } else return;
    }
    
    public void PurchaseBoost8x10min() {
        if (nuts.ResourceAmount >= price && !isBoosting) {
            nuts.ReduceResource(price);
            StartCoroutine(Boosted());
            groundSquirrel.isBoosted5 = true;
            isBoosting = true;
        } else return;
    }
    
}