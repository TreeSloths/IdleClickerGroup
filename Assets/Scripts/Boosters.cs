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
    public float timeModifier = .2f;
    public Storage climberStorage;
    public int price = 1000;
    private bool isBoosting;

    

    
    IEnumerator BoostFor5MIN() {
        yield return new WaitForSeconds(300);
        for (var i = 0; i < squirrels.Count; i++) {
            squirrels[i].speed -= speedModifier;
            transfer[i].WaitTimer += timeModifier;
            storages[i].Capacity -= capacitymodifier;
        }

        for (var i = 0; i < elevatorStorages.Count; i++) {
            elevatorStorages[i].Capacity = capacitymodifier;
        }

        climbingSquirrel.speed -= speedModifier;
        transferClimber.WaitTimer += timeModifier;
        isBoosting = false;
    }

    public void PurchaseBooster() {
        if (nuts.ResourceAmount < price && !isBoosting) {
            return;
        } else {
            nuts.ReduceResource(price);
            for (var i = 0; i < storages.Count; i++) {
                storages[i].Capacity += capacitymodifier;
            }

            for (var i = 0; i < squirrels.Count; i++) {
                squirrels[i].speed += speedModifier;
            }

            for (var i = 0; i < transfer.Count; i++) {
                transfer[i].WaitTimer -= timeModifier;
            }

            for (var i = 0; i < elevatorStorages.Count; i++) {
                elevatorStorages[i].Capacity += capacitymodifier;
            }

           
            climbingSquirrel.speed += speedModifier;
            transferClimber.WaitTimer -= timeModifier;

            StartCoroutine(BoostFor5MIN());
            isBoosting = true;
        }
    }
}