using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExtendUpgradeBanner : MonoBehaviour
{
    public Text text;
    
    private float scale = 0.01f;
    private float maxScale = 1.2f;
    bool done = false;
    bool retract = false;

    private bool render;

        
    public int Ymax;
    public int Ymin;
    public int Xmax;
    public int Xmin;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().enabled = render;
        this.transform.localScale = new Vector3(0.01f,1,1);    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkClickPos();
        this.GetComponent<Image>().enabled = render;

        if (render) text.GetComponent<Text>().enabled = true;
    }



    public void ExtendBanner()
    {

        render = true;
        transform.localScale = new Vector3(scale, Mathf.Clamp(scale,0.5f,maxScale), 1);
        
        scale += 0.05f;
        scale *= 1.5f;
        if (scale >= maxScale)
        {
            scale = maxScale;
        }
    }
    
    public void RetractBanner()
    {

        
        transform.localScale = new Vector3(scale, Mathf.Clamp(scale,0.5f,maxScale), 1);

        done = false;
        
        scale *= 0.8f;
        
        if (scale <= 0.01)
        {
            scale = 0.01f;
            this.render = false;
        }
 
    }
    
    void checkClickPos()
    {
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Input.mousePosition;
//            Debug.Log(pointerData.position);
            if (pointerData.position.x > Xmin && pointerData.position.x < Xmax && pointerData.position.y > Ymin && pointerData.position.y < Ymax )
            {
                ExtendBanner();
            }
            else
            {
                RetractBanner();
            }
        }



    }
}
