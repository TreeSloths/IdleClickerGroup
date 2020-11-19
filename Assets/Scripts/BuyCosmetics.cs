using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCosmetics : MonoBehaviour
{
    public Resource nuts;
    public GameObject cosmetic;

    public bool IsUnlocked {
        get => intToBool(PlayerPrefs.GetInt(name + "bool", 0));
        set => PlayerPrefs.SetInt(name + "bool", boolToInt(value));
    }
    

    private void Update() {
        if (IsUnlocked) {
            cosmetic.SetActive(true);
        }
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
    public int price;
    
    public void CosmeticBought()
    {
        if (nuts.ResourceAmount >= price && !IsUnlocked)
        {
            nuts.ReduceResource(price);
            cosmetic.SetActive(true);
            IsUnlocked = true;
        }
    }
}
