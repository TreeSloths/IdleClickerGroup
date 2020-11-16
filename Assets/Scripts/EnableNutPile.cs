using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNutPile : MonoBehaviour
{
    private Storage storageContainer;

    void Start()
    {
        storageContainer = GetComponent<Storage>();
        GetComponent<SpriteRenderer>().enabled = false;
    }


    void Update()
    {
        if (storageContainer.currentAmount > 0)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
