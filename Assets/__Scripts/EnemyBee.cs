using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBee : MonoBehaviour
{
    [Header("Set in Inspector: Bee")]
    public float speed = 10f;
    public float health = 90;
    public int score = 100;

    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }

    void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        Vector3 temPos = pos;
        temPos.x -= speed * Time.deltaTime;
        pos = temPos;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;
        Debug.Log(tag);
        Debug.Log(health);

        if (tag.Equals("ProjectilePlayer") || tag.Equals("SlicePlayer"))
        {
            health -= 30;
            Debug.Log(health);
        }
        if (health <= 0) Destroy(this.gameObject);
    }
}
