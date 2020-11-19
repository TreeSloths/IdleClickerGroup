using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_UnlockBranch : MonoBehaviour
{
    public Button_UnlockBranch branchUnlocker;
    private GameObject RollingSquirrel;
    [Tooltip("0 = top, 1 = middle, 2 = bottom")]
    public int branch;
    
    // Start is called before the first frame update
    void Start()
    {
        if (branch == 0)
        {
            GameObject myPrefab = GameObject.Find("UnlockBranch (2)");

            if( myPrefab != null )
            {
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
