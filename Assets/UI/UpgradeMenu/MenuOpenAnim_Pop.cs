using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpenAnim_Pop : MonoBehaviour
{
    private float scale = 0.4f;
    bool done = false;
    bool retract = false;
    
    private bool render => FramesDelay <= 0;
    public int FramesDelay = 0;

    void Start()
    {
        this.GetComponent<Image>().enabled = false;

        this.transform.localScale = new Vector3(0.4f,0.4f,0.4f);    
    }

    void FixedUpdate()
    {
        this.GetComponent<Image>().enabled = render;
        FramesDelay--;
        if (FramesDelay <= 0) 
        {
            ScaleUp();
        } 
        
    }


    public void ScaleUp()
    {
        transform.localScale = new Vector3(scale, scale, scale);
        if (!done)
        {
            if (!retract)
            {
                scale *= 1.2f;
                if (scale >= 1.1f) retract = true;
            }
            else
            {
                transform.localScale = new Vector3(scale, scale, scale);
                scale *= 0.95f;
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
