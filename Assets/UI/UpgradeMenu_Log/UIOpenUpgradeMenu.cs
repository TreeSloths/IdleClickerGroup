using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOpenUpgradeMenu : MonoBehaviour
{
    float offsetY = -10.0f;
    
    bool openMenu = false;


    private bool anticipation = true;
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (openMenu) PanUp();
    }

    public void OpenMenu()
    {
        var StartVector = new Vector2(50,0);
        var rect = GetComponent<RectTransform>();
        rect.offsetMax -= StartVector;
        rect.offsetMin -= StartVector;
        openMenu = true;
       // Destroy(gameObject);
    }
    
    void PanUp()
    {
        
        var VectorOffset = new Vector2(0, offsetY);
        var rect = GetComponent<RectTransform>();
        
        rect.offsetMax += VectorOffset;
        rect.offsetMin += VectorOffset;

        if (anticipation)
        {
            offsetY *= 0.98f;
            if (offsetY <= 0.01) anticipation = false;
        }
        else
        {
  
            offsetY = Mathf.Abs(offsetY);
            offsetY *= 1.5f;
            

        }
   
        

    }
}
