using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public float Score;
    public Text ScoreDisplay;

	// Use this for initialization
	void Start () {
        ScoreDisplay.text = "0";
	}
	
    public void UpdateScore(float gain)
    {
        Score += gain;
        ScoreDisplay.text = Score.ToString();
        print("Score: " + Score);
    }
}
