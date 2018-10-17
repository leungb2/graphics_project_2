using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour {

    public float speed = 10.0f;
    private Transform waypoint;
    private int i = 0;

	// Set movement in direction of first waypoint
	void Start ()
    {
        waypoint = Waypoints.waypoints[0];
	}
	
	// Move in the direction of next waypoint
	void FixedUpdate ()
    {
        GetComponent<Rigidbody>().velocity = (waypoint.position - transform.position).normalized * speed;

        if (Vector3.Distance(waypoint.position, transform.position) <= 0.4)
        {
            if (i >= Waypoints.waypoints.Length - 1)
            {
                SceneManager.LoadScene("GameOverLose");
                //Destroy(gameObject);
                return;
            }

            i++;
            waypoint = Waypoints.waypoints[i];
        }
	}
}
