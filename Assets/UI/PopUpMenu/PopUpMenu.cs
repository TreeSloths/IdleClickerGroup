using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMenu : MonoBehaviour
{
    public Text popUpMenuText;
    public Text popupMenuRes;
    public Text popUpMenuResV;
    public SaveTime SaveTime;
    public AddOfflineRes AddOfflineRes;
    
    void Start()
    {
        this.popUpMenuText.text = $"This is the time you were last online: {SaveTime.systemStart}";
        this.popupMenuRes.text = $"This is the amount of resources you have harvested while you were offline:";
        this.popUpMenuResV.text = $"{AddOfflineRes.production}";
    }
}