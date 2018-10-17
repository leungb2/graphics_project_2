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
    public Text upgradeButtonText;

    private GameObject sellButton;
    private GameObject buyButton;
    private GameObject upgradeButton;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameManager.instance;
        money = Money.instance;
        buyButtonText.text = "Buy Tower\n$" + tower.buyValue.ToString();
        sellButton = GameObject.Find("SellTower");
        buyButton = GameObject.Find("BuyTower");
        upgradeButton = GameObject.Find("UpgradeTower");

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (tile.tower != null)
        {
            sellButtonText.text = "Sell Tower\n$" + tile.tower.sellValue.ToString();
            sellButton.SetActive(true);
            buyButton.SetActive(false);

            if (tile.tower.towerLevel >= 3)
            {
                upgradeButtonText.text = "Upgrade Tower\n$0";
                upgradeButton.SetActive(false);
            }
            else
            {
                upgradeButtonText.text = "Upgrade Tower\nto level " + (tile.tower.towerLevel + 1)
                    + "\n$" + tile.tower.upgradeValue.ToString()
                    + "\nIncrease tower range and fire rate";
                upgradeButton.SetActive(true);
            }
        }
        else
        {
            sellButtonText.text = "Sell Tower\n$0";
            upgradeButtonText.text = "Upgrade Tower\n$0";
            sellButton.SetActive(false);
            upgradeButton.SetActive(false);
            buyButton.SetActive(true);
        }
	}

    public void PurchaseTower()
    {
        if (tile.tower == null && money.amount >= tower.buyValue)
        {
            money.amount -= tower.buyValue;
            tile.BuildTower();
        }
        else
        {
            Debug.Log("tower already exists or not enough money!");
        }
    }

    public void SellTower()
    {
        if (tile.tower != null)
        {
            money.amount += tile.tower.sellValue;
            tile.DestroyTower();
        }
        else
        {
            Debug.Log("no tower on tile!");
        }
    }

    public void UpgradeTower()
    {
        if (tile.tower != null && money.amount >= tile.tower.upgradeValue)
        {
            money.amount -= tile.tower.upgradeValue;
            tile.tower.Upgrade();
        }
        else
        {
            Debug.Log("not enough money!");
        }
    }
}
