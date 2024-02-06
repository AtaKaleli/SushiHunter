using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRB;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    [SerializeField] private Animator playerAnim;
    

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
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
        bool isMoving = playerRB.velocity.x != 0;
        playerAnim.SetBool("isMoving", isMoving);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
    }

    private void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(xInput * moveSpeed, playerRB.velocity.y);
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
