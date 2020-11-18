using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSquirrel : MonoBehaviour {
    public SquirrelMovement squirrel;
    public Resource nuts;
    public Storage elevatorStorage;

    public int capacitymodifier = 10;
    public float priceMultiplier = 5f;
    public float speedModifier = 1.1f;
    private Storage storage;
    private TransferStorage transfer;
   // public Text labelText;
    

    public float SquirrelSpeed {
        get => PlayerPrefs.GetFloat(squirrel.name + "Speed", 1.5f);
        set {
            PlayerPrefs.SetFloat(squirrel.name + "Speed", value);
            squirrel.speed = value;
        }
    }

    public int Price {
        get => PlayerPrefs.GetInt(squirrel.name + "UpgradePrice", 100);
        set => PlayerPrefs.SetInt(squirrel.name + "UpgradePrice", value);
    }

    public int Level {
        get => PlayerPrefs.GetInt(squirrel.name + "Level", 0);
        set => PlayerPrefs.SetInt(squirrel.name + "Level", value);
    }

    public int StorageCapacity {
        get => PlayerPrefs.GetInt(squirrel.name + "Capacity", 20);
        set {
            PlayerPrefs.SetInt(squirrel.name + "Capacity", value);
            storage.Capacity = value;
        }
    }

    public float WaitTimer {
        get => PlayerPrefs.GetFloat(squirrel.name + "waitTime", 2f);
        set {
            PlayerPrefs.SetFloat(squirrel.name + "waitTime", value);
            transfer.WaitTimer = value;
        }
    }

    private void Start() {
        storage = squirrel.GetComponent<Storage>();
        transfer = squirrel.GetComponent<TransferStorage>();
       // labelText.text = $"Upgrade for {Price}\n lvl {Level}";
        storage.Capacity = StorageCapacity;
        transfer.WaitTimer = WaitTimer;
        squirrel.speed = SquirrelSpeed;
    }

    private void Update() {
    }

    public void PurchaseUpgrade() {
        if (nuts.ResourceAmount < Price) {
            return;
        } else {
            nuts.ReduceResource(Price);
            SquirrelSpeed *= speedModifier;
            squirrel.speed = SquirrelSpeed;
            StorageCapacity += capacitymodifier;
            WaitTimer -= 0.2f;
            Price *= Mathf.RoundToInt(priceMultiplier);
            elevatorStorage.Capacity += capacitymodifier;
            Level++;
           // labelText.text = $"Upgrade for {Price}\n lvl {Level}";
        }
    }
}
