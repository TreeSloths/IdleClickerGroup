using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nuttap : MonoBehaviour
{
    public Text resValue;
    [Tooltip("Resource type that the Tapper should generate goes here.")]
    public Resource resource;

    public int nutTapLevel
    {
        get => PlayerPrefs.GetInt("nutTapLevel", 0);
        set => PlayerPrefs.SetInt("nutTapLevel", value);
    }
    [Tooltip("Production Amount per click for the tapper at Level 0")]
    public int startingProductionAmount = 2;
    private int _produceAmount;
 

    [Tooltip("Upgrade multiplier starting value. If set to 2 productionValue is doubled")]
    public float productionIncreaseMult = 2;
    [Tooltip("If Set to 1 upgrade multiplier never changes. If Set to < 0.95 upgrade button looses effectiveness very quickly. Recommended values between 0.96 - 0.99")]
    public float productionIncreasePerLevelDampener = 0.98f;
    [Tooltip("The lowest possible percentage increase of production per click amount. if set to 0, upgrade function would stop working after a while. Recommended values between 0.5 and 10")]
    public float productionMinimumIncreasePercentage = 1;
    void Start()
    {
        this.resource.ResourceAmount = PlayerPrefs.GetInt(resource.name);

        _produceAmount = GetProductionAmount();
        Debug.Log("level: " + nutTapLevel + " production per click: " + _produceAmount);


        productionMinimumIncreasePercentage = productionMinimumIncreasePercentage * 0.01f + 1;

    }

    void Update()
    {
        this.resValue.text = resource.ResourceAmount.ToString("0 nuts");
    }

    public void ProduceNuts()
    {
        this.resource.AddResource(_produceAmount);
        
    }


    private int GetProductionAmount()
    {
        if (nutTapLevel == 0) return startingProductionAmount;
        float tempValue = startingProductionAmount;
        float _productionIncreaseMult = productionIncreaseMult;
        for (int i = 0; i < nutTapLevel; i++)
        {
            _productionIncreaseMult *= productionIncreasePerLevelDampener;
            _productionIncreaseMult = Mathf.Clamp(_productionIncreaseMult,productionMinimumIncreasePercentage,productionIncreaseMult);
            
            
            tempValue *= _productionIncreaseMult;
            

        }

        return Mathf.RoundToInt(tempValue);
    }
    
    
    
    public void UpgradeNutTapLevel()
    {

        nutTapLevel++;
        _produceAmount = GetProductionAmount();
        Debug.Log("level: " + nutTapLevel + " production per click: " + _produceAmount);
    }
}