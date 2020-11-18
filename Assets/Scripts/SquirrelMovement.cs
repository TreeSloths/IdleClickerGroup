using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelMovement : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    private bool collided;
    public bool isTransfering;
    public bool isWaiting;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite[] spriteArray;

    public void Movement() {
        if (!isTransfering && !isWaiting) {
            transform.Rotate(new Vector3(0, 0, 360) * speed * Time.deltaTime);
            if (collided) {
                transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
            } else if (!collided) transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
        }
    }
    

    void Update()
    {
        Movement();
        ChangeSprite();
    }

    void ChangeSprite()
    {
        if (isTransfering || isWaiting)
        {
            spriteRenderer.sprite = spriteArray[1];
        }
        else
        {
            spriteRenderer.sprite = spriteArray[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            movingRight = false;
            collided = true;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
            collided = false;
        }
    }
}