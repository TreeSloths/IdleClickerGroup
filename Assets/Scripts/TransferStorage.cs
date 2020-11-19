using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS.Xcode;
using UnityEngine;

public class TransferStorage : MonoBehaviour {
    private Storage myStorage;
    private SquirrelMovement squirrel;
    private Storage storageContainer;
    public bool isBoosted;

    public float WaitTimer {
        get => PlayerPrefs.GetFloat(name+"Timer",2f);
        set => PlayerPrefs.SetFloat(name+"Timer",value);
    }

    private void Start() {
        myStorage = GetComponent<Storage>();
        squirrel = GetComponent<SquirrelMovement>();
    }

    IEnumerator startTransfer() {
        yield return new WaitForSeconds(WaitTimer);
        squirrel.isTransfering = false;
    }

    private void Update() {
        if (squirrel.isWaiting) {
            ElevatorStorageTransfer();
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (myStorage.CurrentAmount > 0) {
            if (other.CompareTag("MotherTree") && !isBoosted) {
                var motherTree = other.GetComponent<MotherTree>();
                squirrel.isTransfering = true;
                StartCoroutine(startTransfer());
                motherTree.nuts.ResourceAmount += myStorage.CurrentAmount;
                myStorage.ReduceAmount(myStorage.CurrentAmount);
            }

            if (other.CompareTag("MotherTree") && isBoosted) {
                var motherTree = other.GetComponent<MotherTree>();
                squirrel.isTransfering = true;
                StartCoroutine(startTransfer());
                motherTree.nuts.ResourceAmount += myStorage.CurrentAmount * 10;
                myStorage.ReduceAmount(myStorage.CurrentAmount);
            }
        }

        if (myStorage.CurrentAmount > 0) {
            if (other.CompareTag("ElevatorStorage")) {
                storageContainer = other.GetComponent<Storage>();
                ElevatorStorageTransfer();
            }
        }

        if (other.CompareTag("Storage")) {
            storageContainer = other.GetComponent<Storage>();
            StorageTransfer();
        }
    }

    private void ElevatorStorageTransfer() {
        var possibleGiveAmount = storageContainer.Capacity - storageContainer.CurrentAmount;
        if (possibleGiveAmount >= myStorage.CurrentAmount) {
            squirrel.isTransfering = true;
            squirrel.isWaiting = false;
            StartCoroutine(startTransfer());
            storageContainer.CurrentAmount += myStorage.CurrentAmount;
            myStorage.ReduceAmount(myStorage.CurrentAmount);
        } else if (possibleGiveAmount <= myStorage.CurrentAmount && possibleGiveAmount != 0) {
            squirrel.isWaiting = false;
            squirrel.isTransfering = true;
            StartCoroutine(startTransfer());
            storageContainer.CurrentAmount += possibleGiveAmount;
            myStorage.ReduceAmount(possibleGiveAmount);
        } else if (possibleGiveAmount == 0) {
            squirrel.isWaiting = true;
        }
    }

    private void StorageTransfer() {
        if (storageContainer.CurrentAmount > 0 && myStorage.CurrentAmount < myStorage.Capacity) {
            var possibleTakeAmaount = myStorage.Capacity - myStorage.CurrentAmount;
            if (possibleTakeAmaount > storageContainer.CurrentAmount) {
                myStorage.CurrentAmount += storageContainer.CurrentAmount;
                storageContainer.ReduceAmount(storageContainer.CurrentAmount);
                squirrel.isTransfering = true;
                StartCoroutine(startTransfer());
            } else {
                myStorage.CurrentAmount += possibleTakeAmaount;
                storageContainer.ReduceAmount(possibleTakeAmaount);
                squirrel.isTransfering = true;
                StartCoroutine(startTransfer());
            }
        } else if (!storageContainer.hasCapacity) {
            squirrel.isTransfering = true;
            StartCoroutine(startTransfer());
            var possibleTakeAmaount = myStorage.Capacity - myStorage.CurrentAmount;
            myStorage.CurrentAmount += possibleTakeAmaount;
        }
    }
}