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
        groundSquirrel.isBoosted = false;
        isBoosting = false;
    }

    public void PurchaseBoost() {
        if (nuts.ResourceAmount >= price && !isBoosting) {
            nuts.ReduceResource(price);
            StartCoroutine(Boosted());
            groundSquirrel.isBoosted = true;
            isBoosting = true;
        } else return;
    }
}