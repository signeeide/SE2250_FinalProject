using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player S; //Singleton
    static public GameObject slice = null;
    public float speed;
    public float health = 200f;
    private Rigidbody2D rb2d;

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

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)) {
            rb2d.velocity = Vector2.up * jumpForce;
        }

        // Allow to fire light projectiles
        if (Input.GetKeyDown(KeyCode.Z)) {
            TempFire();
        }

        if (Input.GetKeyDown(KeyCode.X) && slice == null)
        {
            Slice();
        }
    }

    void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();
        rigidB.velocity = Vector3.right * projectileSpeed;
    }

    void Slice()
    {
        slice = Instantiate<GameObject>(slicePrefab);
        Vector3 temPos = transform.position;
        temPos.x += 0.4f;
        slice.transform.position = temPos;

        //Wait before destroying the slice
        Invoke("DestroySlice", 0.8f);
    }


    void DestroySlice()
    {
        Destroy(slice);
    }
}
