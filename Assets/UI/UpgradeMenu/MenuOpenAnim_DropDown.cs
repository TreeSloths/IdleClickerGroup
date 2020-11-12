using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpenAnim_DropDown : MonoBehaviour
{
    private float scale = 0.01f;
    private float scaler = 0.14f;
    bool done = false;
    bool retract = false;
    private bool render => FramesDelay <= 0;
    public int FramesDelay = 0;
    
    void Start()
    {
        this.GetComponent<Image>().enabled = false;
        this.transform.localScale = new Vector3(1,0.01f,0.01f);    
    }

    void FixedUpdate()
    {
        this.GetComponent<Image>().enabled = render;
        FramesDelay--;
        if (FramesDelay <= 0)
        {
            ScaleUpY();
            
        }
    }
    
    public void ScaleUpY()
    {
        transform.localScale = new Vector3(1, scale, scale);
        if (!done)
        {
            if (!retract)
            {
                if (scaler > 0.01 && scale > 0.8f) scaler *= 0.85f;
                scale += scaler;
                if (scale >= 1.12f)
                {
                    retract = true;
                    scaler = 0.01f;
                }
            }
            else
            {
                transform.localScale = new Vector3(1, scale, scale);
                scaler *= 1.3f;
                scale -= scaler;
                if (scale <= 1)
                {
                    scale = 1;
                    done = true;
                    this.enabled = false;
                }

               
            }
        }
    }
}
