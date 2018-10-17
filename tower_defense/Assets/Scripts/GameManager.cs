using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject shop;
    public Shop shopScript;
    public bool shopOpen;
    public GameObject escMenu;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        shopOpen = false;
        shop.SetActive(false);
        shopScript = shop.GetComponent<Shop>();
        escMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escMenu.SetActive(true);
        }
    }

    public void OpenShop()
    {
        shopOpen = true;
        shop.SetActive(true);
        if (shopScript.tile.tower != null)
        {
            shopScript.tile.tower.towerRangeOn = true;
        }
    }

    public void CloseShop()
    {
        shopOpen = false;
        if (shopScript.tile.tower != null)
        {
            shopScript.tile.tower.towerRangeOn = false;
        }
        shop.SetActive(false);
        shopScript.tile = null;
    }

}
