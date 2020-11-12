using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTime : MonoBehaviour
{
    public string systemStart;
    public string systemQuit;


    private void Start()
    {
        systemStart = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        Debug.Log($"{systemStart}");
    }

    private void OnApplicationQuit()
    {
        systemQuit = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        timeSaveQuit = systemQuit;
    }

    public string timeSaveQuit
    {
        get => PlayerPrefs.GetString("QuitTime", "");
        set => PlayerPrefs.SetString("QuitTime", value);
    }
}