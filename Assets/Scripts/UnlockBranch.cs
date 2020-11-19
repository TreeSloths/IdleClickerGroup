using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockBranch : MonoBehaviour
{
    public Resource nuts;
    public GameObject rollingSquirrel;

    public GameObject UpgradeSquirrelButton;
    
    public GameObject padlockBar;
    public GameObject padlock;
    public Text padlockText;

    public GameObject branch01;
    public GameObject branch02;

    public GameObject banner;
    public bool IsUnlocked {
        get => intToBool(PlayerPrefs.GetInt(name + "bool", 0));
        set => PlayerPrefs.SetInt(name + "bool", boolToInt(value));
    }

    private void Start()
    {
        if (IsUnlocked)
        {
            HideButtonAfterUnlock();
        }
    }

    private void Update() {
        if (IsUnlocked) {
            rollingSquirrel.SetActive(true);
            UpgradeSquirrelButton.GetComponent<Image>().enabled = true;
            padlockBar.GetComponent<PadLockBarAnim>().Unlock();
            this.GetComponent<EmptyGraphic>().enabled = false;

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
    
    public void BranchUnlocked()
    {
        if (nuts.ResourceAmount >= price && !IsUnlocked)
        {
            nuts.ReduceResource(price);
            rollingSquirrel.SetActive(true);
            IsUnlocked = true;
            
            
        }
    }

    public void HideButtonAfterUnlock()
    {
        branch01.GetComponent<Image>().enabled = false;
        branch02.GetComponent<Image>().enabled = false;
        padlockBar.GetComponent<Image>().enabled = false;
        padlock.GetComponent<Image>().enabled = false;
        padlockText.GetComponent<Text>().enabled = false;
        UpgradeSquirrelButton.GetComponent<Image>().enabled = true;
        this.GetComponent<EmptyGraphic>().enabled = false;

        banner.GetComponent<ExtendUpgradeBanner>().enabled = true;
    }
}
