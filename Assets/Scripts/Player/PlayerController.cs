using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRB;
    [SerializeField] private float moveSpeed;




    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(xInput * moveSpeed, playerRB.velocity.y);


    }
}
