using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;

    //sets up the grounded stuff
    bool grounded = false;
    bool touchingWall = false;
    public Transform groundCheck;
    public Transform wallCheck;
    float groundRadius = 0.2f;
    float wallTouchRadius = 0.5f;
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;
    public float jumpForce = 700f;
    public float jumpPushForce = 10f;

    //double jump (if needed)
    private bool doubleJump = false;

    private bool globalWallTouching = false;
    private string direction = "";

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
        }
        else {
            globalWallTouching = false;
        }

        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

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


        if (touchingWall && Input.GetButtonDown("Jump") && ((direction == "LEFT" && facingRight) || (direction == "RIGHT" && !facingRight))) {
            WallJump();
        }

    }

    void WallJump() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpPushForce, jumpForce));
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