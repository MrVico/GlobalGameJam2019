using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControls : MonoBehaviour {

    public float moveSpeed = 10f;
    public int nbFrameBetweenShots;
    public Transform bulletSpawn;
    public GameObject bullet;
    public float speedBullet;
    public int nbPointsCourbeShoot;
    public LineRenderer lineRenderer;
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
    private int framesSinceLastShoot;

    private Animator animator;

    // Use this for initialization
    void Start() {
        framesSinceLastShoot = nbFrameBetweenShots;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        // TESTS
        if (Input.GetKeyDown(KeyCode.A)) {
            //GameObject.Find("HouseDoor").GetComponent<Animator>().SetTrigger("Open");
            //GameObject.Find("GardenDoor").GetComponent<Animator>().ResetTrigger("Close");
        }
        else if (Input.GetKeyDown(KeyCode.E)) {
            //GameObject.Find("HouseDoor").GetComponent<Animator>().SetTrigger("Close");
            //GameObject.Find("GardenDoor").GetComponent<Animator>().ResetTrigger("Open");
        }

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

        framesSinceLastShoot++;

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
            animator.SetTrigger("Jump");
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

        printLineShooting();
        if (GetComponent<PlayerStatus>().bananaMode && framesSinceLastShoot > nbFrameBetweenShots)//&& Input.GetButtonDown("Fire1")
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
                BananaShoot();
            }
            //BananaShoot();
        }
    }

    public Vector3[] printLineShooting()
    {
        const float maxAltitude = 2.0f;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vectorDistance = mousePos - bulletSpawn.transform.position;
        float distance = vectorDistance.magnitude;
        //Vector3 vectorDistanceNormalized = vectorDistance.normalized;
        Vector3[] listControlPoints = new Vector3[4];
        listControlPoints[0] = bulletSpawn.transform.position;
        listControlPoints[1]=bulletSpawn.transform.position + vectorDistance * 1.0f / 3.0f + new Vector3(0, maxAltitude, 0);
        listControlPoints[2]=bulletSpawn.transform.position + vectorDistance * 2.0f / 3.0f + new Vector3(0, maxAltitude, 0);
        listControlPoints[3]=mousePos;

        List<Vector3> pointCasteljau = new List<Vector3>();
        for (int i = 0; i < nbPointsCourbeShoot; i++)
        {
            pointCasteljau.Add(calcPointsCasteljau(listControlPoints, 4,  i * (1.0f / (nbPointsCourbeShoot - 1))));
        }
        lineRenderer.positionCount = pointCasteljau.Count;
        lineRenderer.SetPositions(pointCasteljau.ToArray());

        return listControlPoints;
    }

    public void BananaShoot()
    {
        //Shoot
        Vector3[] controlesPoints = printLineShooting();
        GameObject newBullet = GameObject.Instantiate(bullet);
        newBullet.GetComponent<Bullet>().initialyseBullet(speedBullet,controlesPoints);
        framesSinceLastShoot = 0;
    }

    public Vector3 calcPointsCasteljau(Vector3[] listPtsControles, int ptsControlesCount, float u)
    {
        Vector3[] tempList = new Vector3[ptsControlesCount - 1];

        for (int i = 0; i < ptsControlesCount - 1; i++)
        {
            Vector3 pt1 = listPtsControles[i];
            Vector3 pt2 = listPtsControles[i+1];
            tempList[i] = Vector3.Lerp(pt1, pt2, u);
        }

        if (ptsControlesCount - 1 == 1)
        {
            return tempList[0];
        }

       return calcPointsCasteljau(tempList, ptsControlesCount - 1, u);
        
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