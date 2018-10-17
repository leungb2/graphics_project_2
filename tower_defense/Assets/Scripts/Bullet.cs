using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

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
            Destroy(col.gameObject);
            money.amount += 5;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
