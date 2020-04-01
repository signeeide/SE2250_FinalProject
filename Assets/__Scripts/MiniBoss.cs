using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(42f, 2.27f, 0);
    private Vector3 pos2 = new Vector3(39f, 2.27f, 0);
    public float speed = 1.0f;

    public GameObject projectile;
    public float projSpeed = 3f;
    //public float projPrSec = 1f;
    public int health = 500;

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
       

    }

    void Start()
    {
          
          InvokeRepeating("shootProjectile", 8f / 2f, 3f);
    }
    //start attacking if player is withing a certain distance 


   /* IEnumerator shoot()
    {
        yield return new WaitForSeconds(4);
        InvokeRepeating("shootProjectile", 8f / 2f, 3f);
    }*/
    private void shootProjectile()
    {
        
        // get projectile properties and instansiate projectiles
        GameObject projectileGO = Instantiate<GameObject>(projectile);
        projectileGO.transform.position = transform.position;
        Rigidbody2D rb = projectileGO.GetComponent<Rigidbody2D>(); 
        rb.velocity = Vector3.left * projSpeed;


    }
}
