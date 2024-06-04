using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;

// Flyer AI from brackeys
// Reference: https://www.youtube.com/watch?v=jvtFUfJ6CP8

public class EnemyFlyerAI : MonoBehaviour
{

    public Transform target;

    public Transform enemyGFX;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    private Seeker seeker;
    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If no path, don't move
        if (path == null)
        {
            return;
        }

        // If end of path reached, don't move
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        
        // Move flyer since path not reached yet
        reachedEndOfPath = false;
        
        // Get direction where flyer needs to go
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Check if we need to flip bird
        if (force.x >= 0.01f)
        {
            // Flip sprite in x-direction
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }

    
    }
}
