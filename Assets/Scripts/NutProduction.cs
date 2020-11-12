using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutProduction : MonoBehaviour
{
    private float _elapsedTime;
    public float nutProductiontime;
    public SaveTime SaveTime;

    void Update()
    {
    }

    public void nutProduction()
    {
        if (this._elapsedTime >= nutProductiontime)
        {
            return;
            this._elapsedTime -= this.nutProductiontime;
        }
        else
        {
            return;
        }
    }
}