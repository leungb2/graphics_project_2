using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject enemyDestroyEffect;

    private Money money;


    // Use this for initialization
    void Start()
    {
        money = Money.instance;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
            GameObject effect = Instantiate(enemyDestroyEffect, col.gameObject.transform.position, Quaternion.identity);
            Destroy(effect, 2.0f);
            Destroy(col.gameObject);
            money.amount += 5;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
