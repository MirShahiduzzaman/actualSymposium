using UnityEngine;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]

public class EnemyAI : MonoBehaviour
{
    // What to chase?
    public Transform target;

    //How many times per second we will update our path
    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnd = false;

    //max distance between AI to waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    // The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if(target == null)
        {
            Debug.LogError("No Player Found. PANIC");
            return;
        }

        //Start a path to the target position, return the position to the OnPathComplete method
        seeker.StartPath (transform.position, target.position, OnPathComplete);
    }

    public void OnPathComplete (Path p)
    {
        Debug.Log ("We got a path. Any error? " + p.error);
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
