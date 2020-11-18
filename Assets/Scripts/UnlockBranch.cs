using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBranch : MonoBehaviour
{
    public Resource nuts;
    public GameObject rollingSquirrel;
    private bool isUnlocked;
    public int price;
    
    public void BranchUnlocked()
    {
        if (nuts.ResourceAmount >= price && !isUnlocked)
        {
            nuts.ReduceResource(price);
            rollingSquirrel.SetActive(true);
            isUnlocked = true;
        }
    }
}
