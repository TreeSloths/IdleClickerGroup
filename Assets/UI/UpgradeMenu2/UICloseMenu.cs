using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICloseMenu : MonoBehaviour
{
    float offsetX = -10.0f;
    
    bool closeMenu = false;


    private bool anticipation = true;
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (closeMenu) PanAway();
    }

    public void CloseMenu()
    {
        var StartVector = new Vector2(50,0);
        var rect = GetComponent<RectTransform>();
        rect.offsetMax -= StartVector;
        rect.offsetMin -= StartVector;
        closeMenu = true;
       // Destroy(gameObject);
    }
    
    void PanAway()
    {
        
        var VectorOffset = new Vector2(offsetX, 0);
        var rect = GetComponent<RectTransform>();
        
        rect.offsetMax += VectorOffset;
        rect.offsetMin += VectorOffset;

        if (anticipation)
        {
            offsetX *= 0.98f;
            if (offsetX <= 0.01) anticipation = false;
        }
        else
        {
  
            offsetX = Mathf.Abs(offsetX);
            offsetX *= 1.5f;
            

        }
   
        

        if (offsetX > 1000) Destroy(gameObject);
        
    }
}
