using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public Transform start;
    public Transform enemy1;

    private float timeBetweenEnemies;
    private float timer;
    private int enemy1Count;

	// Use this for initialization
	void Start ()
    {
        timeBetweenEnemies = 5.0f;
        timer = 3.0f;
        enemy1Count = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            Instantiate(enemy1, start.position, Quaternion.identity);
            timer = timeBetweenEnemies;
            enemy1Count--;
        }

        if(enemy1Count <= 0)
        {
            this.enabled = false;
        }
	}
}
