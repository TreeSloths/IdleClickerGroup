using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_OpenUpgradeMenu : MonoBehaviour
{
    public GameObject UI_upgradeMenuPrefab;

    public Transform parent;
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
        var instance = Instantiate(UI_upgradeMenuPrefab);
        instance.transform.SetParent(parent);
    }
}
