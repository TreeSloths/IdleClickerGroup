using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_UpgradeTapper : MonoBehaviour
{
    private Nuttap nutTap;

    private void Start()
    {
        nutTap = FindObjectOfType<Nuttap>();
        
        if (nutTap == null)
        {
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
        }
    }



    public void UpgradeNutTap()
    {
        nutTap.UpgradeNutTapLevel();
    }
}
