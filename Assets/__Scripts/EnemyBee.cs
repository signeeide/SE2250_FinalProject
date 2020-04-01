using UnityEngine;

public class EnemyBee : MonoBehaviour
{
    [Header("Set in Inspector: Bee")]
    public float speed = 10f;
    public float health = 90;
    public int score = 100;

    private SpriteRenderer sprRen;
    private Rigidbody2D rb;
    private bool isRight;
    public static bool leftBoundsOn = false;

    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }

    void Start()
    {
        sprRen = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        isRight = false;
    }
    void Update()
    {
        Move();
    }

    void BoundsInstance()
    {
        // create empty gameobject, set name and tag
        GameObject go = new GameObject();
        go.name = "LeftBounds";
        go.tag = "LeftBounds";

        // add a collider, set its properties.
        BoxCollider2D boundsColl = go.AddComponent<BoxCollider2D>();
        boundsColl.isTrigger = true;
        boundsColl.size = new Vector2(0.19f, 8.76f);
        boundsColl.offset = new Vector2(0f, 4.83f);

        // Set position for empty gameobject
        Vector3 pos = Vector3.zero;
        pos.x = 55.67f;
        pos.y = -0.7f;
        go.transform.position = pos;


    }
    public virtual void Move()
    {
        // flips movement to opposite of current
        if (isRight) rb.velocity = Vector2.right;
        if (!isRight) rb.velocity = Vector2.left;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;

        if (tag.Equals("ProjectilePlayer"))
        {
            health -= 30;
            Destroy(other.gameObject);
        }

        if (tag.Equals("SlicePlayer")) health -= 100;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Main.enemiesDestroied++;
        }


        if (other.tag.Equals("RightBounds"))
        {
            sprRen.flipX = !sprRen.flipX; // Flips sprite to opposite 
            isRight = true;

            // Create leftBounds if not already created
            if (!leftBoundsOn)
            {
                leftBoundsOn = true;
                Invoke("BoundsInstance", 0.1f);
            }
        }

        if (other.tag.Equals("LeftBounds"))
        {
            isRight = false;

            sprRen.flipX = !sprRen.flipX; // Flips sprite to opposite 

        }
    }

}
