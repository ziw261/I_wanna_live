using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour {
    
    // Config
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float climbSpeed = 5f;
    [SerializeField] private Vector2 deathKick = new Vector2(25f, 25f);
    [SerializeField] private float gravityForce = 50f;
    
    // State
    private bool isAlive = true;
    private bool canIDash = false;
    private bool isReversed = false;
    
    
    // Cached Component Reference
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    private CapsuleCollider2D myBodyCollider2D;
    private BoxCollider2D myFeetCollider2D;
    private float gravityScaleAtStart;
    
    // Future TODO
    //private DashAbility dashAbility;
    
    // Methods
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
        myFeetCollider2D = GetComponent<BoxCollider2D>();
        
       //dashAbility = GetComponent<DashAbility>();

    }



    // Update is called once per frame
    void Update() {
        
        if (!isAlive) {
            return;
        }
        
        Run();
        FlipSprite();
        Jump();
        ClimbLadder();
        Die();
        reverseGravity();
        //Dash();
    }

    private void Run() {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");  // from -1 to 1
        
        /*
        if (dashAbility.dashState == DashState.Dashing) {
            return;
        }
        */
        
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);

        myRigidBody.velocity = playerVelocity;
        //print(playerVelocity);
        
        // Set up animation state
        bool isMoving = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", isMoving);
    }

    
    /*
    private void Dash() {
        if(CrossPlatformInputManager.GetButtonDown("Jump")) && canIDash == true){
            if (myRigidBody.velocity.x == 0) {
                return;
            } else if (myRigidBody.velocity.x > 0) {
                dashTimer += Time.deltaTime*3;
                rigidbody.AddForce(Vector3.right*50);
            }
            if(direction == true) {
                dashTimer += Time.deltaTime*3;
                rigidbody.AddForce(Vector3.right*50);
                 
            }
            if (direction == false)
            {
                dashTimer += Time.deltaTime*3;
                rigidbody.AddForce(Vector3.left*50);
            }
        }
         
        if(dashTimer > .5f)
        {
            canIDash = false;
            dashCooldown = true;
        }
        if(dashTimer < .5f && dashCooldown == false)
        {
            canIDash = true;
        }
        if(dashTimer <= 0)
        {
            dashCooldown = false;
        }

    }
    */
    
    
    private void ClimbLadder() {
        if (!myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing"))) {
            
            myAnimator.SetBool("Climbing", false);
            myRigidBody.gravityScale = gravityScaleAtStart;
            return;
        }

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
        myRigidBody.velocity = climbVelocity;
        myRigidBody.gravityScale = 0;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
    }

    private void reverseGravity() {
        // IMPORTANT: Change the build index when release
        if (SceneManager.GetActiveScene().buildIndex == 2) {
            
            if (Input.GetKeyDown(KeyCode.G)) {
                if (!isReversed) {
                    Debug.Log("reversed");
                    Physics2D.gravity = new Vector2(0, 9.8f*gravityForce);
                    isReversed = true;
                    gameObject.transform.rotation = new Quaternion(0,0,180,-gameObject.transform.rotation.w);
                    Debug.Log(isReversed);
                } else {
                    Physics2D.gravity = new Vector2(0, -9.8f*gravityForce);
                    gameObject.transform.rotation = new Quaternion(0,0,0,gameObject.transform.rotation.w);

                    isReversed = false;
                }
                //Debug.Log("WTF");
            }
            
            
        }
    }
    
    
    private void Jump() {

        if (!myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            return; 
        }
        
        
        
        if (CrossPlatformInputManager.GetButtonDown("Jump")) {
            if (isReversed) {
                Physics2D.gravity = new Vector2(0, 100f);
                //Debug.Log("Get into iffffffff");
                Vector2 jumpVelocityToAdd = new Vector2(0f, -jumpSpeed);
                Vector2 tempVelocity = new Vector2(myRigidBody.velocity.x, -myRigidBody.velocity.y);
                myRigidBody.velocity = tempVelocity+jumpVelocityToAdd;
            } else {
                //Debug.Log(Physics2D.gravity);
                Physics2D.gravity = new Vector2(0, -100f);
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                myRigidBody.velocity += jumpVelocityToAdd;
            }
            
        }
    }

    private void Die() {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards"))) {
            
            //reverse back if isreversed
            if (isReversed) {
                Physics2D.gravity = new Vector2(0, -9.8f*gravityForce);
                gameObject.transform.rotation = new Quaternion(0,0,0,gameObject.transform.rotation.w);

                isReversed = false;
            }


            myAnimator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            isAlive = false;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
            
            
        }
    }
    
    // When moving horizontally, flip the sprite to face the correct direction
    private void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed) {
            if (isReversed) {
                transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x)*-1, 1f);

            } else {
                transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
            }
        }
    }
}
