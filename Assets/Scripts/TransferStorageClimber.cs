using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferStorageClimber : MonoBehaviour {
    private Storage myStorage;
    private ClimbingSquirrel squirrel;
    private Storage storageContainer;
    

    private void Start() {
        myStorage = GetComponent<Storage>();
        squirrel = GetComponent<ClimbingSquirrel>();
    }

    IEnumerator startTransfer() {
        yield return new WaitForSeconds(2);
        squirrel.isTransfering = false;
    }

    private void Update() {
        if (squirrel.isWaiting) {
            ElevatorStorageTransfer();
        }
        TurnAroundIfFull();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("ElevatorStorage")) {
            storageContainer = other.GetComponent<Storage>();
            StorageTransfer();
        }

        if (myStorage.currentAmount > 0) {
            if (other.CompareTag("Storage")) {
                storageContainer = other.GetComponent<Storage>();
                ElevatorStorageTransfer();
            }
        }
    }

    private void ElevatorStorageTransfer() {
        var possibleGiveAmount = storageContainer.capacity - storageContainer.currentAmount;
        if (possibleGiveAmount >= myStorage.currentAmount) {
            squirrel.isTransfering = true;
            squirrel.isWaiting = false;
            StartCoroutine(startTransfer());
            storageContainer.currentAmount += myStorage.currentAmount;
            myStorage.ReduceAmount(myStorage.currentAmount);
        } else if (possibleGiveAmount <= myStorage.currentAmount && possibleGiveAmount != 0) {
            squirrel.isWaiting = false;
            squirrel.isTransfering = true;
            StartCoroutine(startTransfer());
            storageContainer.currentAmount += possibleGiveAmount;
            myStorage.ReduceAmount(possibleGiveAmount);
        } else if (possibleGiveAmount == 0) {
            squirrel.isWaiting = true;
        }
    }

    private void StorageTransfer() {
        if (storageContainer.currentAmount > 0 && myStorage.currentAmount < myStorage.capacity) {
            var possibleTakeAmaount = myStorage.capacity - myStorage.currentAmount;
            if (possibleTakeAmaount > storageContainer.currentAmount) {
                myStorage.currentAmount += storageContainer.currentAmount;
                storageContainer.ReduceAmount(storageContainer.currentAmount);
                squirrel.isTransfering = true;
                StartCoroutine(startTransfer());
            } else {
                myStorage.currentAmount += possibleTakeAmaount;
                storageContainer.ReduceAmount(possibleTakeAmaount);
                squirrel.isTransfering = true;
                StartCoroutine(startTransfer());
            }
        } else if (!storageContainer.hasCapacity) {
            squirrel.isTransfering = true;
            StartCoroutine(startTransfer());
            var possibleTakeAmaount = myStorage.capacity - myStorage.currentAmount;
            myStorage.currentAmount += possibleTakeAmaount;
        }
    }

    private void TurnAroundIfFull()
    {
        if (myStorage.currentAmount >= myStorage.capacity)
        {
            transform.eulerAngles = new Vector3(180, 0, 0);
            squirrel.movingUp = false;
            squirrel.collided = true;
        }
    }
}