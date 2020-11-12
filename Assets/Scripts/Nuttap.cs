using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nuttap : MonoBehaviour
{

    public Resource resource;
    public int produceAmount;
    public Text resValue;
    
    void Start()
    {
        this.resource.ResourceAmount = PlayerPrefs.GetInt(resource.name);
    }
    
    void Update()
    {
        this.resValue.text = resource.ResourceAmount.ToString("0 nuts");
    }

    public void ProduceNuts()
    {
        this.resource.AddResource(produceAmount);
    }
    
    
}
