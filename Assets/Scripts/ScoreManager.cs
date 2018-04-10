using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public float Score;
    public Text ScoreDisplay;

	void Start () {
        ScoreDisplay.text = "0";
	}
	
    public void UpdateScore(float gain)
    {
		Score += gain;
		ScoreDisplay.text = Math.Round(Score, 1).ToString();
    }
}
