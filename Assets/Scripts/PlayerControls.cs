using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    public float moveSpeed = 10f;

    [SerializeField] Transform groundCheck;
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] LayerMask whatIsWall;
    [SerializeField] float jumpForce = 700f;
    [SerializeField] float jumpPushForce = 10f;
    [SerializeField] float wallJumpForce = 700f;
    [SerializeField] float wallJumpPushForce = 10f;

    bool facingRight = true;    
    bool grounded = false;
    bool touchingWall = false;
    float groundRadius = 0.2f;
    float wallTouchRadius = 0.5f;

    //double jump (if needed)
    private bool doubleJump = false;

    private bool globalWallTouching = false;
    private string direction = "";
    private int framesSinceWallTouch = 5;
    private int framesSinceLastWallJump = 0;

    /**

        If he touches the wall for the first time we store his direction
        The player can then only wall jump if he faces the opposite direction

    **/

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {

        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        touchingWall = Physics2D.OverlapCircle(wallCheck.position, wallTouchRadius, whatIsWall);

        if (grounded) {
            doubleJump = false;
        }

        if (touchingWall) {
            if (!globalWallTouching) {
                globalWallTouching = true;
                if (facingRight)
                    direction = "RIGHT";
                else
                    direction = "LEFT";
            }
            grounded = false;
            doubleJump = false;
            framesSinceWallTouch = 0;
        }
        else {
            framesSinceWallTouch++;
            globalWallTouching = false;
        }

        framesSinceLastWallJump++;

        float move = Input.GetAxis("Horizontal");
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !facingRight) {
            // ... flip the player.
            Flip();
        }// Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && facingRight) {
            // ... flip the player.
            Flip();
        }
    }
    void Update() {
        
        // If the jump button is pressed and the player is grounded then the player should jump.
        if ((grounded /*|| !doubleJump*/) && Input.GetButtonDown("Jump")) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            // Decomment this if we only want to bounce once off the wall
            /*
            if (!doubleJump && !grounded) {
                doubleJump = true;
            }
            */
        }
        
        if (/*touchingWall*/framesSinceWallTouch < 15 && Input.GetButtonDown("Jump") 
            && ((direction == "LEFT" && facingRight) || (direction == "RIGHT" && !facingRight))
            && framesSinceLastWallJump > 20) {
            WallJump();
            framesSinceWallTouch = 15;
        }

    }

    void WallJump() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(wallJumpPushForce, wallJumpForce));
        Debug.Log("Frames since last wall jump: " + framesSinceLastWallJump);
        framesSinceLastWallJump = 0;
    }


    void Flip() {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        //Multiply the player's x local cale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}