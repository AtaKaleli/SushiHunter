using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRB;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;




    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

    }

    private void Jump()
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
    }

    private void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(xInput * moveSpeed, playerRB.velocity.y);
    }
}
