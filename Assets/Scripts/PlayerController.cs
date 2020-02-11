using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    private enum State { idle, running, jumping, falling }
    private State state = State.idle;
    
    [SerializeField] private LayerMask platform;
    [SerializeField] private float speed = 5f; // Скорость
    [SerializeField] private float acceleration = 3f; // Ускорение движения
    [SerializeField] private float jumpForce = 10f; // Сила прыжка
    [SerializeField] private float drag = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

    }

    private void Update()
    {
        
        if ((state == State.falling) || (state == State.jumping))
        {
            rb.drag = 0;
        }
        else
        {
            rb.drag = drag;
        }
        
        InputMovement();
        StateSwitch();
        anim.SetInteger("state", (int)state);
    }

    private void InputMovement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if ((hDirection < 0) && (coll.IsTouchingLayers(platform)) && (rb.velocity.magnitude < speed))
        {
            rb.AddForce(new Vector2(-speed * acceleration, 0), ForceMode2D.Force);
            transform.localScale = new Vector2(-1, 1);
        }
        // Движение вправо
        else if ((hDirection > 0) && (coll.IsTouchingLayers(platform)) && (rb.velocity.magnitude < speed))
        {
            rb.AddForce(new Vector2(speed * acceleration, 0), ForceMode2D.Force);
            transform.localScale = new Vector2(1, 1);
        }

        // Прыжок
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(platform))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
        }
    }

    private void StateSwitch()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(platform))
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
}
