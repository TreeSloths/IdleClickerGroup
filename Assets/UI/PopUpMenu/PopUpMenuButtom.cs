using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopUpMenuButtom : MonoBehaviour
{

    public GameObject popUpMenu;
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void ClosePopUp()
    {
        popUpMenu.SetActive(false);
    }
    
}
