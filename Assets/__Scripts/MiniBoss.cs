﻿using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(42f, 2.27f, 0);
    private Vector3 pos2 = new Vector3(39f, 2.27f, 0);
    public float speed = 1.0f;

    public GameObject projectile;
    public float projSpeed = 3f;
    //public float projPrSec = 1f;
    public int health = 500;

    void Start()
    {
        InvokeRepeating("shootProjectile", 8f / 2f, 3f);
    }
    //start attacking if player is withing a certain distance 

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }

   /* IEnumerator shoot()
    {
        yield return new WaitForSeconds(4);
        InvokeRepeating("shootProjectile", 8f / 2f, 3f);
    }*/
    private void shootProjectile()
    {
        // get projectile properties and instansiate projectiles
        GameObject projectileGO = Instantiate<GameObject>(projectile);
        //projectileGO.transform.position = transform.position;
        projectileGO.transform.position.Set(transform.position.x + 3f, transform.position.y, transform.position.z); 
        Rigidbody2D rb = projectileGO.GetComponent<Rigidbody2D>(); 
        rb.velocity = Vector3.left * projSpeed;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;
        Debug.Log("Miniboss: " + tag);

        if (tag.Equals("ProjectilePlayer")) health -= 30;
        
        if (tag.Equals("SlicePlayer")) health -= 100;

        if (health <= 0) {
            Destroy(this.gameObject);
            BlockShow.isVisible = true; //When he is defeated the blocks appear
        }
    }
}
