using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public float PlayerSpeed;

    private Rigidbody2D rb;
    private Animator anim;
    private bool faceRight = true;
    private float PlayerDirection;
    private static readonly int isMoving = Animator.StringToHash(name:"isMoving");
    private static readonly int isGrounded = Animator.StringToHash(name:"isGrounded");
    private static readonly int isRunning = Animator.StringToHash(name:"isRunning");
    private static readonly int isOnTopOfSkate = Animator.StringToHash(name:"isOnTopOfSkate");
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        Move();
        Animate();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift ) || Input.GetKey(KeyCode.RightShift))
        {
            PlayerDirection *= 2;
        }
        
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool(isOnTopOfSkate, true);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool(isOnTopOfSkate, false);
        }

        rb.velocity = new Vector2(PlayerDirection * PlayerSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 10);
        }
    }

    private void Animate()
    {
        if (PlayerDirection > 0 && !faceRight)
        {
            FlipCharachter();
        }
        else if (PlayerDirection < 0 && faceRight)
        {
            FlipCharachter();
        }
        anim.SetBool(isMoving, PlayerDirection != 0);
        anim.SetBool(isGrounded, rb.velocity.y == 0);
       //anim.SetBool(isRunning, rb.velocity.x > PlayerSpeed);
    }

    private void ProcessInput()
    {
        PlayerDirection = Input.GetAxis("Horizontal");
    }

    private void FlipCharachter()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
