using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BranchMenuUI : MonoBehaviour
{
    float offsetX = -10.0f;
    
    bool closeMenu = false;


    private bool anticipation = true;
    
    // Start is called before the first frame update
    void Start()
    {
        var rect = GetComponent<RectTransform>();
        rect.offsetMax = Vector2.zero;
        rect.offsetMin = Vector2.zero;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (closeMenu) PanAway();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) checkClickPos();
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
    
    void checkClickPos()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;
        Debug.Log(pointerData.position);
        if (pointerData.position.x > 1140 && pointerData.position.x < 1620 && pointerData.position.y > 390 && pointerData.position.y < 960)
        {
            //Mouse is inside menu
        }
        else
        {
            CloseMenu();
        }

    }
}
