using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText, restartText, gameOverText;
    
    private int score;
    private bool gameOver, restart;

    void Start()
    {
        StartCoroutine(SpawnWaves());
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        restartText.text = "";
        gameOverText.text = "";
        gameOver = false;
        restart = false;
    }

    void Update()
    {
        if(restart && Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

       while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void Gamover ()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
