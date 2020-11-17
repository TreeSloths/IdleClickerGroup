using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSway : MonoBehaviour
{
    private float X;
    private float timeMult;


    // Start is called before the first frame update
    void Start()
    {
        
        X += Random.Range(0f, 1f);
        timeMult += Random.Range(2f, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rect = GetComponent<Transform>();
        X += Time.deltaTime*timeMult;
        rect.rotation = Quaternion.Euler(0,0,Mathf.Sin(X)*1.5f);

    }


}
