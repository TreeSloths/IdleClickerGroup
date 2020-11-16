using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class LogRumble : MonoBehaviour
{
    private float X;
    private float magnitude;
    private float magnitudeBounce;
    private float frequency;
    public bool rumbles = false;
    
    private Grass grass;
    private void Start()
    {
        grass = FindObjectOfType<Grass>();
    }

    void FixedUpdate()
    {
        if (rumbles) rumble();
        else
        {
            X = 0;
            magnitude = 0;
        }
    }

    void rumble()
    {
        magnitudeBounce *= 0.6f;
        magnitude *= 0.88f;
        frequency *= 1.1f;
        if (frequency > 60)
        {
            magnitude = 0;
            rumbles = false;
        }
        var rect = GetComponent<RectTransform>();
        X += Time.deltaTime*frequency;
        rect.rotation = Quaternion.Euler(0,0,Mathf.Sin(X)*magnitude);
        rect.localPosition = new Vector2(0,-30 + (magnitude-magnitudeBounce)*4);


    }
    void startRumble()
    {
        grass.SendMessage("ShockWave");
        X = 0;

        magnitude = 30;
        magnitudeBounce = 30;
        frequency = 7;
        rumbles = true;
        
    }
}
