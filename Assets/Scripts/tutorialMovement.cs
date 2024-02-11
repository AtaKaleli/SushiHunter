using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;
    

    [SerializeField] private Animator anim;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        Movement();
        JumpCollisionDetection();

        if (isGrounded)
            Jump();

        AnimationControllers();
       

    }

   

    private void AnimationControllers()
    {

        anim.SetFloat("xVelocity", rb.velocity.x);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void JumpCollisionDetection()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    


}
