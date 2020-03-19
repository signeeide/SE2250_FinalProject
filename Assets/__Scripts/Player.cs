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
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

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

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (rb2d.velocity.y < 0)
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);

        //Allow to fire balls
        if (Input.GetKeyDown(KeyCode.Space)) {
            TempFire();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log("Collision detected!");
    }


    void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.up * projectileSpeed;
    }
}
