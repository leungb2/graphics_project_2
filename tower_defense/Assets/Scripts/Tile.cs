using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public Color highlightColor;
    public Tower towerPrefab;
    public Tower tower;

    private Renderer r;
    private Color tileColor;
    private GameManager gameManager;

    // Use this for initialization
    void Start ()
    {
        r = GetComponent<Renderer>();
        tileColor = r.material.color;
        tower = null;
        gameManager = GameManager.instance;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnMouseEnter()
    {
        r.material.color = highlightColor;
    }

    void OnMouseExit()
    {
        r.material.color = tileColor;
    }

    void OnMouseDown()
    {
        if (gameManager.shopOpen == false)
        {
            gameManager.shopOpen = true;
            gameManager.shopScript.tile = this;
            gameManager.openShop();
        }
        else
        {
            gameManager.closeShop();
            gameManager.shopScript.tile = this;
            gameManager.openShop();
        }

    }

    public void buildTower()
    {
        tower = Instantiate<Tower>(towerPrefab);
        tower.transform.position = new Vector3(this.transform.position.x, 2.5f, this.transform.position.z);
    }

    public void destroyTower()
    {
        Destroy(tower.gameObject);
        tower = null;
    }
}
