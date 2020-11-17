
using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class UpgradeMenu : MonoBehaviour
{
    
    private float posY = -480;
    private float posYclose = 1f;
    private bool open = false;
    public bool opening = false;
    public bool closing = false;
    
    public bool closed =>closing == false && opening == false && open == false;

        
    

    // Start is called before the first frame update
    void Start()
    {
        

        
        var rect = GetComponent<RectTransform>();
        rect.offsetMax = new Vector2(0,posY);
        rect.offsetMin = new Vector2(0,posY);
        
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) checkClickPos();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (opening && !open) OpenMenu();
        if (closing && !closed) CloseMenu();

 
    }

    void OpenMenu()
    {
        var VectorTop = new Vector2(0,posY);
        var VectorBottom = new Vector2(0,posY);
        
        var rect = GetComponent<RectTransform>();
        rect.offsetMax = VectorTop;
        rect.offsetMin = VectorBottom;


        posY *= 0.92f;


        if (posY >= -0.001)
        {
            posY = 0;
            open = true;
            opening = false;
            posYclose = 1f;
        }
    }
    
    void CloseMenu()
    {
        posYclose *= 1.2f;
        posY -= posYclose;
        if (posY < -480)
        {
            
            var LogHeader = FindObjectOfType<LogRumble>();
            LogHeader.SendMessage("startRumble");
            posY = -480;
    
            posYclose = 1f;
            
            closing = false;
            open = false;
            opening = false;
        }
        
        var VectorTop = new Vector2(0,posY);
        var VectorBottom = new Vector2(0,posY);
        
        var rect = GetComponent<RectTransform>();
        rect.offsetMax = VectorTop;
        rect.offsetMin = VectorBottom;

        
    }
    
    public void OpenOnClick()
    {
        this.opening = true;
    }

    void checkClickPos()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        if (pointerData.position.x > 950+190 && pointerData.position.x < 1450+190 && pointerData.position.y < 560)
        {
            //Mouse is inside menu
            //TODO: make dynamic solution to check if mouse cursor is outside menu or not, with raycasts maybe.
        }
        else
        {
            if (!closed) closing = true;
            opening = false;
            open = false;
        }

    }

}
