using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMenu : MonoBehaviour
{

    public Text popUpMenuText;
    public SaveTime SaveTime;

    private double comparing1;
    private double comparing2;
    private double comparing3;
    
    
    void Start()
    {
        
       comparing1 = Convert.ToDouble(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
       comparing2 = Convert.ToDouble(SaveTime.systemQuit);
       comparing3 = comparing1 - comparing2;

        this.popUpMenuText.text = $"Welcome back, this is the current time of your system: {comparing3}";
    }
    
    void Update()
    {
        
    }
}
