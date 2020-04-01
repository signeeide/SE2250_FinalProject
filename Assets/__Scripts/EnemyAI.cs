using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDist = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEnd = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        // repeatingly generates path
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        // if path generation is done / not currently happening
        if (seeker.IsDone())
        {
            // generates path
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0; // resets path
        }
    }

 
    void FixedUpdate()
    {
        // if there are no paths, return
        if (path == null) return;

        // If there are no more paths, the end is reached.
        // else, it is not the end.
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEnd = true;
            return;
        } else
        {
            reachedEnd = false;
        }

        // get current waypoint, substract current position
        // normalized to ensure length of vector = 1 
        Vector2 dir = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = dir * speed * Time.deltaTime;

        //adds force to enemy
        rb.AddForce(force);

        // figure out distance to next waypoint
        float dist = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        // current waypoint reached
        if(dist < nextWaypointDist)
        {
            // move to next waypoint
            currentWaypoint++;
        }

        // Flips the enemy graphics
        if (force.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-2f, 2f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(2f, 2f, 1f);
        }

    }
}
