using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    public static Money instance;
    public Text moneyText;
    public int amount;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        amount = 500;
	}
	
	// Update is called once per frame
	void Update ()
    {
        moneyText.text = "$" + amount.ToString();
	}
}
