using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public GameManager gameManager;
    public Money money;
    public Tile tile;
    public Tower tower;
    public Text sellButtonText;
    public Text buyButtonText;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameManager.instance;
        money = Money.instance;
        buyButtonText.text = "BuyTower\n$" + tower.buyValue.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (tile.tower != null)
        {
            sellButtonText.text = "SellTower\n$" + tower.sellValue.ToString();
        }
        else
        {
            sellButtonText.text = "SellTower\n$0";
        }
	}

    public void purchaseTower()
    {
        if (tile.tower == null && money.amount > tower.buyValue)
        {
            tile.buildTower();
            money.amount -= tower.buyValue;
        }
        else
        {
            Debug.Log("tower already exists or not enough money!");
        }
    }

    public void sellTower()
    {
        if (tile.tower != null)
        {
            tile.destroyTower();
            money.amount += tower.sellValue;
        }
        else
        {
            Debug.Log("no tower on tile!");
        }
    }
}
