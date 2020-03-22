﻿using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    static public Player S; //Singleton
    static public GameObject slice = null;
    public float speed;
    public float health = 200f;
    private Rigidbody2D rb2d;
    public Animator animator; // Animator

    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    public GameObject slicePrefab;
    public float projectileSpeed = 20f;

    //jump
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Transform feetPosition;
    public float jumpForce;


    // Use this for initialization
    void Awake()
    {
        if(S == null) {
            S = this;
        }
        else {
            Debug.LogError("Hello.Awake() - Attempted to assign second Hero.S!");
        }
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();

    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        //Get 'speed' from animator, and set equal to moveHorizontal.
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * jumpForce;
            // Triggers jump
            animator.SetTrigger("Jump");
        }

        // Handles in-air jump and landing animations
        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
        }
        else animator.SetBool("IsJumping", true);


        // Allow to fire light projectiles
        if (Input.GetKeyDown(KeyCode.Z)) {
            TempFire();
        }

        if (Input.GetKeyDown(KeyCode.X) && slice == null)
        {
            Slice();
        }
    }

    private void StartPosition()
    {
        Vector3 temPos = transform.position;
        temPos.x = 1.85f;
        temPos.y = 1.61f;
        transform.position = temPos;
    }

    private void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();
        rigidB.velocity = Vector3.right * projectileSpeed;
    }

    private void Slice()
    {
        slice = Instantiate<GameObject>(slicePrefab);
        Vector3 temPos = transform.position;
        temPos.x += 0.5f;
        slice.transform.position = temPos;

        //Wait before destroying the slice
        Invoke("DestroySlice", 0.5f);
    }

    private void DestroySlice()
    {
        Destroy(slice);
    }

}
