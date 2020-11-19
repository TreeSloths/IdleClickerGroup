using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadLockBarAnim : MonoBehaviour
{
    private int delay = 0;

    private float offsetY = 1;
    private float YStartPosition;
    private Vector2 position;

    public UnlockBranch unlockBranch;
    public GameObject banner;
    
    private bool unlock = false;

    // Start is called before the first frame update
    void Start()
    {
        
        YStartPosition = this.transform.localPosition.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (unlock) UnlockAnim();
        if (delay >= 20)
        {
            banner.GetComponent<ExtendUpgradeBanner>().enabled = true;
            unlockBranch.HideButtonAfterUnlock();
        }
    }

    public void Unlock()
    {
        unlock = true;
    }
    void UnlockAnim()
    {

     position = new Vector2(this.transform.localPosition.x,YStartPosition+offsetY);
        
        var rect = GetComponent<RectTransform>();
        rect.localPosition = position;

 
        offsetY *= 1.2f;
        offsetY += 1;
        if (offsetY > 30)
        {
            offsetY = 30;
            delay++;
        }
    }
}
