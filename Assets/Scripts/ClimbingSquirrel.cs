using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingSquirrel : MonoBehaviour
{
    public float speed;
    public bool movingUp = true;
    public bool collided;
    public bool isTransfering;
    public bool isWaiting;

    public void Movement() {
        if (!isTransfering && !isWaiting) {
            if (collided) {
                transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
            } else if (!collided) transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
        }
    }

    void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (movingUp == true)
        {
            transform.eulerAngles = new Vector3(180, 0, 0);
            movingUp = false;
            collided = true;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingUp = true;
            collided = false;
        }
    }
}