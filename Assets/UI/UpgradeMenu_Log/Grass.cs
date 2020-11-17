using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    private float X;
    float grassFoldX = 0;
    // Start is called before the first frame update
    void Start()
    {
        X += Random.Range(0, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rect = GetComponent<RectTransform>();
        X += Time.deltaTime*2;
        rect.rotation = Quaternion.Euler(0,0,Mathf.Sin(X)*2f);

    }


}
