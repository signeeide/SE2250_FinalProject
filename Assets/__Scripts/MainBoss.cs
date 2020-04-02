using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBoss : MiniBoss
{
    private int health = 800;

    // sets boss health
    public override void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag.Equals("ProjectilePlayer")) health -= 30;
    
        if (tag.Equals("SlicePlayer")) health -= 100;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
