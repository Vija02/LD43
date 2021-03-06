﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 130f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    public Animator animator;

    const float k_GroundedRadius = .05f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;


    public bool enableWalk = true;

    // Jumping forces
    public bool enableJump = true;
    public bool enableDoubleJump = true;
    private bool ableToDoubleJump = false; // To know when the user released the jump key
    private bool doubleJumped = false; // Whether double jumped used or not

    private bool wasJumping = false;
    public float airTime = 0.05f; // This is the duration where pressing jump will still make a difference
    private float currentAirTime = 0f; // Current count

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        currentAirTime -= Time.fixedDeltaTime;

        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                GetComponent<Animator>().SetBool("isOnGround", true);
                wasJumping = false;
                ableToDoubleJump = false;
                doubleJumped = false;
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if(move == 0)
        {
            stopWalkSound();
        }
        else if(m_Grounded && enableWalk)
        {
            playWalkSound();
        }

        if (wasJumping && !jump)
        {
            ableToDoubleJump = true;
        }
        if (!wasJumping && jump && enableJump)
        {
            playJumpSound();
            stopWalkSound();
            currentAirTime = airTime;
            wasJumping = true;
        }
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {

            // If crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            // Move the character by finding the target velocity
            if (enableWalk || !m_Grounded)
            {
                Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
                // And then smoothing it out and applying it to the character
                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
                
                if(move != 0)
                {
                    GetComponent<Animator>().SetBool("isWalking", true);
                }
                else
                {
                    GetComponent<Animator>().SetBool("isWalking", false);
                }

            }
            
            

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (enableJump && jump && currentAirTime > 0)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            GetComponent<Animator>().SetBool("isOnGround", false);
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce * (currentAirTime /airTime)));
        }
        if (enableDoubleJump && ableToDoubleJump && !doubleJumped && jump)
        {
            playJumpSound();
            currentAirTime = airTime;
            doubleJumped = true;
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0f);
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

   // Let the player stick to the moving platform once they collided //
     private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Moving Platform")
        { 
            transform.parent = other.transform;
        }

    }

    // Free the player when it jumps off //
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Moving Platform")
        {
            transform.parent = null;
        }
    }

    public void playJumpSound()
    {
        gameObject.transform.Find("Sounds/Jumps").gameObject.GetComponent<AudioSource>().Play();
    }

    public void playWalkSound()
    {
        AudioSource audioSource = gameObject.transform.Find("Sounds/Walk").gameObject.GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            gameObject.transform.Find("Sounds/Walk").gameObject.GetComponent<AudioSource>().Play();
        }
    }
    public void stopWalkSound()
    {
        gameObject.transform.Find("Sounds/Walk").gameObject.GetComponent<AudioSource>().Stop();
    }
}
