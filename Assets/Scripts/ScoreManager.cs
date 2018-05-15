using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
<<<<<<< HEAD
=======

>>>>>>> fabrício
    public static ScoreManager Instance;

    public float Score;
    public Text ScoreDisplay;

    private void Awake()
    {
        //Check if instance already exists
        if (Instance == null)
            //if not, set instance to this
            Instance = this;

        //If instance already exists and it's not this:
        else if (Instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

<<<<<<< HEAD
    // Use this for initialization
    void Start () {
=======
	void Start () {
>>>>>>> fabrício
        ScoreDisplay.text = "0";
	}
	
    public void UpdateScore(float gain)
    {
		Score += gain;
<<<<<<< HEAD
		if ((Math.Round(Score, 1) * 10) % 10 == 0) {
			ScoreDisplay.text = Math.Round(Score, 1).ToString() + ".0";
		} else {
			ScoreDisplay.text = Math.Round(Score, 1).ToString();
		}
=======
        UpdateScore();
    }

    public void UpdateScore()
    {
        ScoreDisplay.text = Math.Round(Score, 1).ToString();
        SaveManager.Instance.currentScore = Score;
>>>>>>> fabrício
    }
}
