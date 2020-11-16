using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    public GameObject Map;

    public void getMap()
    {
        if (this.Map != null)
        {
            bool active = Map.activeSelf;
            Map.SetActive(!active);
        }
    }
}
