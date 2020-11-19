using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemOpenAnim_Pop : MonoBehaviour
{
    public bool enabled;

    private bool PopIn;

    public float ScaleSpeed = 1.2f;
    public float maxScale = 1.1f;
    public float retractSpeed = 0.95f;
    
    
    public int FramesDelay = 0;
    private int framesDelay;
    private float scale = 0.4f;
    bool done = false;
    bool retract = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().enabled = this.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
     
    }

    private void FixedUpdate()
    {
        framesDelay--;
        if (PopIn && framesDelay <= 0) ScaleUp();
    }

    public void TabEnable()
    { 
        this.enabled = true;
        
        scale = 0.4f;
        retract = false;
        done = false;
        PopIn = true;

        framesDelay = FramesDelay;
    }
    public void TabDisable()
    {
        this.enabled = false;
        this.GetComponent<Image>().enabled = this.enabled;
    }
    
    
    public void ScaleUp()
    {
        this.GetComponent<Image>().enabled = this.enabled;
        transform.localScale = new Vector3(scale, scale, scale);
        if (!done)
        {
            if (!retract)
            {
                scale = Mathf.Clamp(scale, 0, maxScale);
                scale *= ScaleSpeed;
                if (scale >= maxScale) retract = true;
                
            }
            else
            {
                transform.localScale = new Vector3(scale, scale, scale);
                scale *= retractSpeed;
                if (scale <= 1)
                {
                    scale = 1;
                    done = true;
                    PopIn = false;
                }
            }
        }
    }
    
}
