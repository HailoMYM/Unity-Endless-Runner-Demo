using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    public float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;
    private int multipleJump;
    public int baseMultipleJump;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    public GameManager theGameManager;
    //private Collider2D myCollider;

    private Animator myAnimator;
	public Transform headerY;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent <Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
			
        stoppedJumping = true;
        jumpTimeCounter = jumpTime;
        multipleJump = baseMultipleJump;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

    }
	
	// Update is called once per frame

	void FixedUpdate ()
	{
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		// Incremento de velocidad
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            moveSpeed *= speedMultiplier;
            speedIncreaseMilestone *= speedMultiplier;
			myAnimator.speed *= speedMultiplier;
        }


        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0) && Input.mousePosition.y < headerY.position.y  ) )
        {
			
            if (grounded)
            {
				
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
            }

            if (!grounded && multipleJump > 0)
            {
				
                jumpTimeCounter = jumpTime;
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
                multipleJump--;
            }
        }

        if ( (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) ) && !stoppedJumping )
        {
			
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
			
            stoppedJumping = true;
            jumpTimeCounter = 0;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            multipleJump = baseMultipleJump;
        }

        myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool  ("Grounded", grounded);
		myAnimator.SetBool ("Jumping", myRigidbody.velocity.y > 0);
		myAnimator.SetBool ("MultipleJump", multipleJump == 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "killbox")
        {
			myAnimator.SetBool  ("Dead", true);
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            theGameManager.RestartGame();
        }
    }
}
