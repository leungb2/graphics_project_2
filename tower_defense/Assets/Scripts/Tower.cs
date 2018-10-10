using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject target;
    public Bullet bulletPrefab;
    public float range = 15.0f;
    public int buyValue = 300;
    public int sellValue = 150;

    private float timer;
    private float shootTimer;

	// Use this for initialization
	void Start () {
        target = null;
        timer = 0.0f;
        shootTimer = 2.0f;
        InvokeRepeating("Target", 0.0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if (target == null) {
            return;
        }

        if (timer <= 0.0f)
        {
            Shoot();
            timer = shootTimer;
        }
	}

    void Target()
    {
        if (target != null && Vector3.Distance(target.transform.position, transform.position) > range)
        {
            target = null;
        }

        if (target == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            float shortestDistance = Mathf.Infinity;

            foreach (GameObject enemy in enemies)
            {
                float enemyDistance = Vector3.Distance(enemy.transform.position, transform.position);
                if (enemyDistance <= shortestDistance)
                {
                    shortestDistance = enemyDistance;
                    target = enemy;
                }
            }

            if (shortestDistance > range)
            {
                target = null;
            }
        }
    }

    void Shoot ()
    {
        Bullet bullet = Instantiate<Bullet>(bulletPrefab);
        Vector3 bulletOrigin = new Vector3(this.transform.position.x, 2.5f, this.transform.position.z);
        bullet.transform.position = bulletOrigin;
        bullet.dir = (target.transform.position - bulletOrigin).normalized;
    }
}
