/*
 * (Luke Hensley)
 * (Prototype 5)
 * (Controls the functions of the game)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restart;

    private int score;

    public bool isGameActive;

    public GameObject titleScreen;

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void gameOver()
    {
        isGameActive = false;
        restart.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    public void startGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        updateScore(0);
        titleScreen.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
