using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogMouseOverPop : MonoBehaviour
{
    private float popPosition;

    private UpgradeMenu state;
    private LogRumble logRumble;

    
    // Start is called before the first frame update
    void Start()
    {
        state = GetComponentInParent<UpgradeMenu>();
        logRumble = GetComponent<LogRumble>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkClickPos();

    }
    
    void checkClickPos()
    {
        if (state.closed && !logRumble.rumbles)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Input.mousePosition;

            if (pointerData.position.x > 990 && pointerData.position.x < 1790 && pointerData.position.y < 120)
            {
                MouseEnterAnim();
            }
            else
            {
                MouseLeaveAnim();
            }
        }
        else
        {
            MouseLeaveAnim();
        }

        void MouseLeaveAnim()
        {
            var rect = GetComponent<RectTransform>();
            rect.localPosition = new Vector2(0, -30 +popPosition);
            popPosition -= 3f;
            if (popPosition < 0) popPosition = 0;
        }
        void MouseEnterAnim()
        {
            var rect = GetComponent<RectTransform>();
            rect.localPosition = new Vector2(0, -30 + popPosition);
            popPosition += 4f;
            if (popPosition > 30) popPosition = 30;
        }
    }
}
