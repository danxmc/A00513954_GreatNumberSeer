using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seer : MonoBehaviour {
    //Attributes
    private int min;
    private int max;
    private int guess;
    public int attempts;
    public Text guessLabel;
    LevelManager levelManager;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        StartGame();
        ShowGuess();
	}

    // Update is called once per frame
    void Update () {
		
	}

    void StartGame()
    {
        min = 1;
        max = 1001;
        NextGuess();
    }

    void NextGuess()
    {
        guess = UnityEngine.Random.Range(min, max);
        attempts--;
    }

    void ShowGuess()
    {
        if (attempts >= 0)
        {
            guessLabel.text = "Is your number " + guess + "?\n\nAttempts : " + attempts;
        } else
        {
            levelManager.LoadLevel("win");
        }
    }

    public void GuessHigher()
    {
        min = guess + 1;
        NextGuess();
        ShowGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
        ShowGuess();
    }

    public void CorrectGuess()
    {
        levelManager.LoadLevel("lost");
    }
}
