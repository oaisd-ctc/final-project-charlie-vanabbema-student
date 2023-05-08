using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpSpeed = 16f;
    [SerializeField] float climbSpeed = 10f;
    [SerializeField] float flySpeed = 0.1f;
    [SerializeField] Vector2 deathKick = new Vector2 (20f, 20f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    [SerializeField] GrappleRope grappleRope;

    bool isAlive = true;

    public bool isLookingRight = true;

    float gravityScaleAtStart;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    void Update()
    {
        if(!isAlive) {return;}
        if(myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground","Ladder")))
        {
        Run();
        // FlipSprite();
        ClimbLadder();
        myAnimator.SetBool("isGrappling", false);
        }
        else
        {
            Fly();
        }
        Die();

        if(grappleRope.isGrappling)
        {
            myAnimator.SetBool("isGrappling", true);
        }
        // else
        // {
        //     myAnimator.SetBool("isGrappling", false);
        // }
    }

    void OnFire(InputValue value)
    {
        if(!isAlive) {return;}
        if(grappleRope.isGrappling == false)
        {
            Instantiate(bullet, gun.position, gun.transform.rotation);   
        }
        
        
    }

    void OnJump(InputValue value)
    {
        if(myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground","Ladder")))
        {
        if(!isAlive) {return;}
        
            if(value.isPressed)
            {
                //do stuff
                myRigidbody.velocity += new Vector2 (0f, jumpSpeed);
            }
        }
        


    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity; 

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;  
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed && !grappleRope.isGrappling);
    }

    void OnMove(InputValue value)
    {
        if(!isAlive) {return;}
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Fly()
    {
        Vector2 playerVelocity = new Vector2(myRigidbody.velocity.x + moveInput.x * flySpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        // playverVelocity = myRigidbody.velocity
    }

    void FlipSprite()
    {

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.Rotate(0f, 180f, 0f);
            // transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
        
    }

    void ClimbLadder()
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity; 
        myRigidbody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;  
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
    }

    void Die()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidbody.velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }


}
