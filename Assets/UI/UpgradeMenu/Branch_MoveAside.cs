using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Branch_MoveAside : MonoBehaviour
{


    public bool directionLeft;
    private float offsetX = 1;
    private float xStartPosition;
    private Vector2 position;
    
    public int Ymax;
    public int Ymin;
    private int Xmax = 980;
    private int Xmin = 620;
    
    // Start is called before the first frame update
    void Start()
    {

        xStartPosition = this.transform.localPosition.x;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkClickPos();
        
        if (offsetX == 30)
        {
  
            this.transform.SetSiblingIndex(0);
        }
        else
        {
            this.transform.SetSiblingIndex(10);
        }
    }


    
    
    void checkClickPos()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;
        if (pointerData.position.x > Xmin && pointerData.position.x < Xmax && pointerData.position.y > Ymin && pointerData.position.y < Ymax)
        {
            MouseEnterAnim();
   
        }
        else
        {
            MouseLeaveAnim();

        }

        offsetX = Mathf.Clamp(offsetX, 0.001f, 30);
    
        
        void MouseEnterAnim()
        {
            if (directionLeft) position = new Vector2(xStartPosition-offsetX,this.transform.localPosition.y);
            else if (!directionLeft) position = new Vector2(xStartPosition+offsetX,this.transform.localPosition.y);
        
            var rect = GetComponent<RectTransform>();
            rect.localPosition = position;

 
            offsetX *= 2;
            offsetX += 1;
            if (offsetX > 30) offsetX = 30;
        }
        void MouseLeaveAnim()
        {
            if (directionLeft) position = new Vector2(xStartPosition-offsetX,this.transform.localPosition.y);
            else if (!directionLeft) position = new Vector2(xStartPosition+offsetX,this.transform.localPosition.y);
        
            var rect = GetComponent<RectTransform>();
            rect.localPosition = position;

 
            offsetX *= 0.8f;
        }

    }

   public void DestroyObject()
    {
        Destroy(this);
    }
}
