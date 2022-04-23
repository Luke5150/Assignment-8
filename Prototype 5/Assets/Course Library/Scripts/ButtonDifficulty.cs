/*
 * (Luke Hensley)
 * (Prototype 5)
 * (Controls the difficulty of the game)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDifficulty : MonoBehaviour
{

    private Button button;

    private GameManager gameManager;

    public int difficulty;

 
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(setDifficulty);

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

  void setDifficulty()
    {
        gameManager.startGame(difficulty);
    }
}
