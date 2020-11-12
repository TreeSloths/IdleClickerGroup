using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferStorage : MonoBehaviour {
    private Storage myStorage;

    private void Start() {
        myStorage = GetComponent<Storage>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (myStorage.currentBucketAmount > 0) {
            if (other.CompareTag("MotherTree")) {
                var motherTree = other.GetComponent<MotherTree>();
                motherTree.nuts.ResourceAmount += myStorage.currentBucketAmount;
                myStorage.ReduceAmount(myStorage.currentBucketAmount);
            }
        }

        if (other.CompareTag("Storage")) {
            var storageContainer = other.GetComponent<Storage>();
            if (storageContainer.currentBucketAmount > 0 && myStorage.currentBucketAmount < myStorage.capacity) {
                var possibleTakeAmaount = myStorage.capacity - myStorage.currentBucketAmount;
                if (possibleTakeAmaount > storageContainer.currentBucketAmount) {
                    myStorage.currentBucketAmount += storageContainer.currentBucketAmount;
                    storageContainer.ReduceAmount(storageContainer.currentBucketAmount);
                } else {
                    myStorage.currentBucketAmount += possibleTakeAmaount;
                    storageContainer.ReduceAmount(possibleTakeAmaount);
                }
            }
        }
    }
}