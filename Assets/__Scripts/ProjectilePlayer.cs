using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProjectilePlayer : MonoBehaviour
{
    public float damage;
    public GameObject player;
    GameObject child;

    void Start()
    {
        //BoxCollider2D bxColl = player.GetComponentInChildren<BoxCollider2D>();
        //child = player.transform.GetChild(1).gameObject;
        //child.SetActive(false);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (!other.gameObject.name.Equals("Player"))
        {
            Destroy(this.gameObject);
            if(other.gameObject.layer.Equals("Enemy"))
            {
                damage = 30f;
            }

        }

    }

}
