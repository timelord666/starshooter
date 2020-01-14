using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameConroller : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public Text textScore;
    public Text restartText;
    public Text gameOverText;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waitWave;
    private int score;
    private bool gameOver;
    private bool restart;
    


     void Start()
    {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        score = 0;
        updateScore();
        StartCoroutine(spawnWaves());
        
        
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator spawnWaves()
    {

        yield return new WaitForSeconds(startWait);


        while(true)
        {
            for (int i = 0; i <= hazardCount; i++)
            {

                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                if (gameOver)
                {
                    restartText.text = "Press 'R' to restart";
                    restart = true;
                    break;
                }


            }
        
            yield return new WaitForSeconds(waitWave);

          

        }

       


    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        updateScore();
    }

     void updateScore()
    {
        textScore.text = "Score " + score;
    }


}

