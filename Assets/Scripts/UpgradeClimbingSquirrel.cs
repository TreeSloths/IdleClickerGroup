using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeClimbingSquirrel : MonoBehaviour {
      public ClimbingSquirrel squirrel;
    public Resource nuts;
    public Storage groundStorage;

    public int capacitymodifier = 50;
    public float priceMultiplier = 2.2f;
    public float speedModifier = 1.3f;
    private Storage storage;
    private TransferStorageClimber transfer;

    private float timeModifier;
   // public Text labelText;
    

    public float SquirrelSpeed {
        get => PlayerPrefs.GetFloat(squirrel.name + "Speed", 1.5f);
        set {
            PlayerPrefs.SetFloat(squirrel.name + "Speed", value);
            squirrel.speed = value;
        }
    }

    public int Price {
        get => PlayerPrefs.GetInt(squirrel.name + "UpgradePrice", 150);
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
        transfer = squirrel.GetComponent<TransferStorageClimber>();
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
            Price *= Mathf.RoundToInt(priceMultiplier);
            groundStorage.Capacity += capacitymodifier;
            Level++;
            if (WaitTimer > 0.5) {
                WaitTimer -= 0.05f;
            }
           // labelText.text = $"Upgrade for {Price}\n lvl {Level}";
        }
    }
}

