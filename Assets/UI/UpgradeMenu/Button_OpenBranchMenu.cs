using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_OpenBranchMenu : MonoBehaviour
{
    public Branch_MoveAside branchMoveLeft;
    public Branch_MoveAside branchMoveRight;
    
    public GameObject UpgradeMenuPrefab;
    public Transform Canvas;
    public GameObject branch;
    private float scaler = 0;
    const int ConstantX = 1;
    
    
    public int Ymax;
    public int Ymin;
    public int Xmax;
    public int Xmin;
    
    public void OpenUpgradeMenu()
    {
        
        GameObject myPrefab = GameObject.Find("BranchMenuChecker");
        
        
        var instance = Instantiate(UpgradeMenuPrefab);
        instance.transform.SetParent(Canvas);

        

        if( myPrefab != null )
        {
            var instances = instance.GetComponentsInChildren<MenuOpenAnim_Pop>();
            foreach (var Instance in instances)
            {
                Instance.FramesDelay = 10;
            }
        }

        
    }
    
    void FixedUpdate()
    {
        checkClickPos();

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
        
        
        
        void MouseEnterAnim()
        {
            branch.transform.localScale = new Vector2(ConstantX + scaler,  ConstantX + scaler);
            scaler += 0.05f;
            if (scaler > 0.1f) scaler = 0.1f;
        }
        void MouseLeaveAnim()
        {
            branch.transform.localScale = new Vector2(ConstantX + scaler, ConstantX + scaler);
            scaler -= 0.05f;
            if (scaler < 0) scaler = 0;
                    
        }

    }
}
