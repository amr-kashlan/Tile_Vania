using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovmentScript : MonoBehaviour
{
    public float runSpeed = 10;
    public float jumpSpeed = 10;
    public float climbSpeed = 3;
    public bool isOnGround;
    CapsuleCollider2D myColider;
    BoxCollider2D myFeet;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    public bool idAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myColider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!idAlive)
        {
            return;
        }
        myRigidbody.gravityScale = 8;
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }
    void OnMove(InputValue value)
    {
        if (!idAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    void OnJump(InputValue value)
    {
        if (!idAlive)
        {
            return;
        }
        if (value.isPressed && myFeet.IsTouchingLayers(LayerMask.GetMask("Level")))
        {

            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
            Debug.Log(1);
        }

        Debug.Log(11);
    }
    void Run()
    {

        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        myAnimator.SetBool("isRunning", hasHorizontalSpeed);
    }
    void ClimbLadder()
    {

        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("climbing")))
        {
            myAnimator.SetBool("isClimbing", false);
            return;

        }
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);

        bool isClimbing = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myRigidbody.velocity = climbVelocity;
        myAnimator.SetBool("isClimbing", isClimbing);
        myRigidbody.gravityScale = 0;
    }
    void FlipSprite()
    {

        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
    void Die()
    {
        Debug.Log(22);
        if (myColider.IsTouchingLayers(LayerMask.GetMask("enemyy", "spikes")))
        {
            idAlive = false;
            myAnimator.SetTrigger("dieing");
            myRigidbody.gravityScale = -2;
            FindObjectOfType<GameSesion>().ProccesPlayerDeth();
        }

    }

}
