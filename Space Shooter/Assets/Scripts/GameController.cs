using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int score;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    private bool restart;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    

    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine (SpawnWaves());
        score = 0;
        UpdateScore();
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/_Scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }
    private void Update()
    {
        if (restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPostition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPostition, spawnRotation);
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

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
