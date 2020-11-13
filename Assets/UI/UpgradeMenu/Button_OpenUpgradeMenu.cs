using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_OpenUpgradeMenu : MonoBehaviour
{
    public GameObject UpgradeMenuPrefab;
    public Transform Canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUpgradeMenu()
    {
        var instance = Instantiate(UpgradeMenuPrefab);
        instance.transform.SetParent(Canvas);
    }
}
