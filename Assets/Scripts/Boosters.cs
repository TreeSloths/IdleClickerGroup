using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boosters : MonoBehaviour {
    public List<SquirrelMovement> squirrels = new List<SquirrelMovement>();
    public Resource nuts;
    public List<Storage> elevatorStorages = new List<Storage>();

    public int capacitymodifier = 10;
    public float speedModifier = 1.30f;
    public List<Storage> storages = new List<Storage>();
    public List<TransferStorage> transfer = new List<TransferStorage>();
    public ClimbingSquirrel climbingSquirrel;
    public TransferStorageClimber transferClimber;
    public Storage climberStorage;
    public int price = 1000;
    private List<float> originalSpeed = new List<float>(new[] {0f, 0f, 0f, 0f});
    private List<int> origianlStorageValue = new List<int>(new[] {0, 0, 0, 0 ,0});
    private List<float> originalWaitTimer = new List<float>(new[] {0f, 0f, 0f, 0f});
    private List<int> origianlElevatorStorageValue = new List<int>(new[] {0, 0, 0, 0, 0});


    private float originalClimbSpeed;
    private float originClimbWaitTime;

    
    IEnumerator BoostFor1MIN() {
        yield return new WaitForSeconds(60f);
        for (var i = 0; i < 4; i++) {
            squirrels[i].speed = originalSpeed[i];
            transfer[i].waitTimer = originalWaitTimer[i];
            storages[i].capacity = origianlStorageValue[i];
        }

        for (var i = 0; i < 4; i++) {
            elevatorStorages[i].capacity = origianlElevatorStorageValue[i];
        }

        climbingSquirrel.speed = originalClimbSpeed;
        transferClimber.waitTimer = originClimbWaitTime;
    }

    public void PurchaseBooster() {
        if (nuts.ResourceAmount < price) {
            return;
        } else {
            nuts.ReduceResource(price);
            for (var i = 0; i < 4; i++) {
                origianlStorageValue[i] = storages[i].capacity;
                storages[i].capacity += capacitymodifier;
            }

            for (var i = 0; i < 4; i++) {
                originalSpeed[i] = squirrels[i].speed;
                squirrels[i].speed *= speedModifier;
            }

            for (var i = 0; i < 4; i++) {
                originalWaitTimer[i] = transfer[i].waitTimer;
                transfer[i].waitTimer -= 0.2f;
            }

            for (var i = 0; i < 4; i++) {
                origianlElevatorStorageValue[i] = elevatorStorages[i].capacity;
                elevatorStorages[i].capacity += capacitymodifier;
            }

            originalClimbSpeed = climbingSquirrel.speed;
            climbingSquirrel.speed *= speedModifier;
            originClimbWaitTime = transferClimber.waitTimer;
            transferClimber.waitTimer -= 0.2f;

            StartCoroutine(BoostFor1MIN());
        }
    }
}