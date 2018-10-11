using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public Transform start;
    public Transform enemy1;
    public int lastRound;
    public Text roundText;

    private float timeBetweenEnemies;
    private float timer;
    private int enemy1Count;
    private int round;
    private bool roundFinished;
    private GameObject[] currentEnemies;
    private GameObject playNextRound;

    // Use this for initialization
    void Start ()
    {
        roundText.text = "Round: " + round;
        round = 1;
        lastRound = 3;
        roundFinished = true;
        playNextRound = GameObject.Find("NextRound");
        timeBetweenEnemies = 0.0f;
        timer = 0.0f;
        enemy1Count = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        roundText.text = "Round: " + round;

        timer -= Time.deltaTime;

        if (timer <= 0.0f && enemy1Count > 0 && !roundFinished)
        {
            Instantiate(enemy1, start.position, Quaternion.identity);
            timer = timeBetweenEnemies;
            enemy1Count--;
        }

        currentEnemies = GameObject.FindGameObjectsWithTag("enemy");

        if(enemy1Count <= 0 && currentEnemies.Length <= 0)
        {
            playNextRound.SetActive(true);

            if (!roundFinished)
            {
                if (round == lastRound)
                {
                    SceneManager.LoadScene("GameOverWin");
                }
                else
                {
                    Debug.Log("completed round!");

                }

                round++;
                roundFinished = true;
            }

        }
        else
        {
            playNextRound.SetActive(false);
        }
	}

    public void nextRound()
    {
        timeBetweenEnemies = 3.0f;
        timer = 2.0f;
        enemy1Count = 3;
        roundFinished = false;
    }
}
