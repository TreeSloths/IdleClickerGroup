using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingClouds : MonoBehaviour
{
    private float currentscroll;
    private float speed = 0.03f;
    void Start()
    {
    
    }

    void Update()
    { 
        var _material = GetComponent<SpriteRenderer>().material;
        currentscroll += speed * Time.deltaTime;
        _material.mainTextureOffset = new Vector2(currentscroll, 0);
    }
}
