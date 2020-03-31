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
    public static bool isStartPositionLv1 = true;
    public static bool isStartPositionLv2 = true;
    public float gameRestartDelay = 2f;

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
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;


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

        if (!isStartPositionLv1 && SceneManager.GetActiveScene().name.Equals("Scene1")) PlayerPosition(60.17f);
        
        else if (!isStartPositionLv2 && SceneManager.GetActiveScene().name.Equals("Scene2")) PlayerPosition(45.72f);
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
        if(Input.GetKeyDown(KeyCode.R) && Main.progress >= 2)
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
    }

    public void DelayedStartPosition(float delay)
    {
        Invoke("StartPosition", delay);
    }

    private void Lv1StartPosition()
    {
        Vector3 temPos = transform.position;
        temPos.x = 2.76f;
        temPos.y = 1.61f;
        transform.position = temPos;
    }

    private void PlayerPosition(float x)
    {
        Vector3 temPos = transform.position;
        temPos.x = x;
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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string name = other.gameObject.name;

        /* In Scene0 */
        if (name == "CastleExit")
        {
            isStartPositionLv1 = true;
            Main.ChangeScene("Scene1");
        }


        /* In scene1 */ 
        if (name == "CastleEntrance") Main.ChangeScene("Scene0");

        if (name == "frog")
        {
            if (Main.progress == 0) DialogCanvas.gameIsPausedFrog = true;
            if (Main.progress == 1) DialogCanvas.gameIsPausedFrog = true;
        }

        if (name == "Lv1Exit" && Main.progress == 2)
        {
            Main.ChangeScene("Scene2");
            isStartPositionLv2 = true;
        }


        /* Scene2 */
        if (name == "Lv2Entrance")
        {
            isStartPositionLv1 = false;
            Main.ChangeScene("Scene1");
        }

        if (name == "TriggerBrick") BlockShow.isVisible = true; //TO DO: Put this in miniboss so that when he is defeated the blocks appear

        else if (name == "OutsideLv") PlayerPosition(2f);

        else if (name == "Chest") Main.progress++;

        if (name == "Lv2Exit") Main.ChangeScene("Boss");


        /* In Boss scene */
        if (name == "BossEntrance")
        {
            isStartPositionLv2 = false;
            Main.ChangeScene("Scene2");
        }
    }
}
