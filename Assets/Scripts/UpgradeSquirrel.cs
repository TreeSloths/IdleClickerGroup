using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSquirrel : MonoBehaviour {
    private SquirrelMovement squirrel;
    public Resource nuts;


    public float priceMultiplier = 5f;
    public float speedModifier = 1.1f;
    private Storage storage;
    private TransferStorage transfer;
    public Text labelText;

    public float SquirrelSpeed {
        get => PlayerPrefs.GetFloat(squirrel.name + "Speed", 1.5f);
        set {
            PlayerPrefs.SetFloat(squirrel.name + "Speed", value);
            squirrel.speed = value;
        }
    }

    public int Price {
        get => PlayerPrefs.GetInt(squirrel.name + "UpgradePrice", 400);
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
            storage.capacity = value;
        }
    }

    public float WaitTimer {
        get => PlayerPrefs.GetFloat(squirrel.name + "waitTime", 2f);
        set {
            PlayerPrefs.SetFloat(squirrel.name + "waitTime", value);
            transfer.waitTimer = value;
        }
    }

    private void Start() {
        squirrel = GetComponent<SquirrelMovement>();
        storage = squirrel.GetComponent<Storage>();
        transfer = squirrel.GetComponent<TransferStorage>();
        labelText.text = $"Upgrade for {Price}\n lvl {Level}";
        storage.capacity = StorageCapacity;
        transfer.waitTimer = WaitTimer;
        squirrel.speed = SquirrelSpeed;
        if (Level == 1) {
        }
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
            StorageCapacity += 50;
            WaitTimer -= 0.2f;
            Price *= Mathf.RoundToInt(priceMultiplier);
            Level++;
            labelText.text = $"Upgrade for {Price}\n lvl {Level}";
        }
    }
}