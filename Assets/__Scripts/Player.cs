using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player S; //Singleton
    public float speed;            
    private Rigidbody2D rb2d;

    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;

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

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);

        Debug.Log(isGrounded);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)) {
            rb2d.velocity = Vector2.up * jumpForce;
        }

        /*Allow to fire balls
        if (Input.GetKeyDown(KeyCode.Space)) {
            TempFire();
        }*/
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log("Collision detected!");
    }
    /*
    static void jump(Player p)
    {
        if (p.rb2d.velocity.y < 0)
            p.rb2d.velocity += Vector2.up * Physics2D.gravity.y * (p.fallMultiplier - 1) * Time.deltaTime;

        else if (p.rb2d.velocity.y > 0 && !Input.GetKeyUp(KeyCode.Space))
            p.rb2d.velocity += Vector2.up * Physics2D.gravity.y * (p.lowJumpMultiplier - 1) * Time.deltaTime;
    }*/

    void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.up * projectileSpeed;
    }
}
