using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TabButton : MonoBehaviour
{
    
    public Sprite down;
    public Sprite up;

    public bool downstate;
    
    // Start is called before the first frame update
    void Start()
    {
        if (downstate) GetComponent<Image>().sprite = down;
        else GetComponent<Image>().sprite = up;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void buttonDown()
    {
        if (!downstate)
        {
            downstate = !downstate;
            GetComponent<Image>().sprite = down;
        }

        
    }

    public void buttonUp()
    {
        if (downstate)
        {
            downstate = !downstate;
            GetComponent<Image>().sprite = up;
        }
    }
}
