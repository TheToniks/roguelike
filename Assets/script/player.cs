using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public float health;

    public void ChangeHealth(int healthValue)
    {
        health += healthValue;
    }

    private bool facingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
     void Update()
    {
        Vector2 moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput * speed;

        if (!facingRight && moveInput.x > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput.x < 0)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
