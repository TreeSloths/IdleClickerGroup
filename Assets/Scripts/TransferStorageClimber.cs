using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferStorageClimber : MonoBehaviour {
    private Storage myStorage;
    private ClimbingSquirrel squirrel;
    private Storage storageContainer;
    public float waitTimer = 2;

    private void Start() {
        myStorage = GetComponent<Storage>();
        squirrel = GetComponent<ClimbingSquirrel>();
    }

    IEnumerator startTransfer() {
        yield return new WaitForSeconds(waitTimer);
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

        if (myStorage.CurrentAmount > 0) {
            if (other.CompareTag("Storage")) {
                storageContainer = other.GetComponent<Storage>();
                ElevatorStorageTransfer();
            }
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
    private void TurnAroundIfFull()
    {
        if (myStorage.CurrentAmount >= myStorage.Capacity)
        {
            transform.eulerAngles = new Vector3(180, 0, 0);
            squirrel.movingUp = false;
            squirrel.collided = true;
        }
    }
}