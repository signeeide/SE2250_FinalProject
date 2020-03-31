using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    static public Player S; //Singleton
    static public GameObject slice = null;
    public float speed;
    public float health = 200f;
    private Rigidbody2D rb2d;
    public Animator animator; // Animator
    public static bool isStartPosition = true;

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

    //Controllers for animation
    public RuntimeAnimatorController heroDefaultController;
    public RuntimeAnimatorController heroRedController;
    //public RuntimeAnimatorController heroBlueController;  //Ready for implementation

    // Attack
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


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

        if (!isStartPosition)
        {
            Lv1ExitPosition();
        }
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        //Helps movement and flipping the player when turning left
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        //Get 'speed' from animator, and set equal to moveHorizontal.
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * jumpForce;
            // Triggers jump
            animator.SetTrigger("Jump");
        }

        // Handles in-air jump and landing animations
        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
        }
        else animator.SetBool("IsJumping", true);


        // Allow to fire light projectiles
        if (Input.GetKeyDown(KeyCode.Z)) {
            animator.SetTrigger("Shoot");
            TempFire();
        }

        // Allow to player to "slice"
        if (Input.GetKeyDown(KeyCode.X) && slice == null)
        {
            // Plays player-slice animation
            animator.SetTrigger("Slice");
           // Slice();
        }

        //Change color to red + boost speed
        if(Input.GetKeyDown(KeyCode.R))
        {
            animator.runtimeAnimatorController = heroRedController as RuntimeAnimatorController;
            speed += 2f;
        }

        //Change color back to default
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.runtimeAnimatorController = heroDefaultController as RuntimeAnimatorController;
            speed -= 2f;
        }

        //Special things for scene2:
        if(SceneManager.GetActiveScene().name == "Scene2")
        {

        }

    }

    public void DelayedStartPosition(float delay)
    {
        Invoke("StartPosition", delay);
    }

    private void Lv1StartPosition()
    {
        Vector3 temPos = transform.position;
        temPos.x = 1.85f;
        temPos.y = 1.61f;
        transform.position = temPos;
    }

    private void Lv1ExitPosition()
    {
        Vector3 temPos = transform.position;
        temPos.x = 64.17f;
        temPos.y = 1.61f;
        transform.position = temPos;
    }

    private void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();
        rigidB.velocity = Vector3.right * projectileSpeed;
    }

    private void Slice()
    {
        // Detecting enemies in range specified radius.
        Collider2D[] atkEnemies; //store all enemies that are hit
        atkEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Loops through all the enemies to deal damage
        foreach(Collider2D enemy in atkEnemies)
        {
            Debug.Log("We hit " + enemy.name);
        }

        /*
        slice = Instantiate<GameObject>(slicePrefab);
        Vector3 temPos = transform.position;
        temPos.x += 0.5f;
        slice.transform.position = temPos;

        //animator.SetTrigger("Slash");

        //Wait before destroying the slice
        Invoke("DestroySlice", 0.5f); */
    }

    private void DestroySlice()
    {
        Destroy(slice);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string name = other.gameObject.name;
        Debug.Log(name);

        //TO DO: Put this in miniboss so that when he is defeated the blocks appear
        if (name == "TriggerBrick")
        {
            BlockShow.isVisible = true;
        }

        else if (name == "CastleEntrance")
        {
            Main.ChangeScene("Scene0");
        }

        else if (name == "CastleExit")
        {
            Main.ChangeScene("Scene1");
            isStartPosition = true;
        }

        else if( name == "Lv1Exit")
        {
            Main.ChangeScene("Scene2");
        }

        else if (name == "Lv2Entrance")
        {
            Main.ChangeScene("Scene1");
            isStartPosition = false;
        }

        else if (name == "Lv2Exit")
        {
            //Main.ChangeScene("Scene3");
        }
    }

}
