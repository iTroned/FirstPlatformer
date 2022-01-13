using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCon : MonoBehaviour
{
    SpriteRenderer render;
    Animator controller;
    Rigidbody2D ri;
    public float speed = 60f;
    bool isRunning = false;
    bool isGrounded = false;
    public float jumpForce;
    public float rayLength;
    void Start()
    {
        ri = gameObject.GetComponent<Rigidbody2D>();
        controller = gameObject.GetComponent<Animator>();
        render = gameObject.GetComponent<SpriteRenderer>();
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * -1, rayLength);
        if(hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    void Update()
    {
        

        

        if (Input.GetKey(KeyCode.D))
        {
            ri.AddForce(transform.right * speed, ForceMode2D.Force);
            isRunning = true;
            render.flipX = false;
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ri.AddForce(transform.right * speed * -1, ForceMode2D.Force);
            isRunning = true;
            render.flipX = true;
        }
        else
        {
            isRunning = false;
        }
        if(isRunning == true)
        {
            controller.SetBool("Running", true);
        }
        else
        {
            controller.SetBool("Running", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        if (isGrounded == true)
        {
            controller.SetTrigger("Jump");
            ri.AddForce(transform.up * jumpForce);
        }
    }
   
}
