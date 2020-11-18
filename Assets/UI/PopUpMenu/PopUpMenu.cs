using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMenu : MonoBehaviour
{

    public Text popUpMenuText;
    public SaveTime SaveTime;

    private long comparing1;
    private double comparing2;
    private double comparing3;
    
    
    void Start()
    {
        // nu minus då
        
        



        this.popUpMenuText.text = $"Welcome back, This is the time you were last online: {SaveTime.timeSaveQuit}" +
                                  $"Test";
    }
    
    void Update()
    {
        
    }
}
