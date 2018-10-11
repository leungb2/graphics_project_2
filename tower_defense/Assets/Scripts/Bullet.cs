using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Vector3 dir;
    public float speed = 1.0f;

    private Money money;


    // Use this for initialization
    void Start()
    {
        money = Money.instance;

    }

    // Update is called once per frame
    void Update ()
    {
        this.transform.Translate(dir * speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
            money.amount += 5;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
