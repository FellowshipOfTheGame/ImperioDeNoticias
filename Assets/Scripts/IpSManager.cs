using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IpSManager : MonoBehaviour {

	[SerializeField] [Range(0, 1)] private float era = 0.01f;
	[SerializeField] private float IpSGain;
	[SerializeField] private float multiplier;
	[SerializeField] private Text IpSDisplay;

	private ScoreManager SM;
	private float time;

	private void Start()
	{
		time = 0;
		SM = gameObject.GetComponent<ScoreManager> ();
		IpSDisplay.text = "+0 IpS";
	}

	void Update () 
	{
		time += Time.deltaTime;

		if (time >= era)
		{
			SM.UpdateScore (IpSGain * multiplier * era);
		}
	}

	void IncreaseIpS (int value) 
	{
		IpSGain += value;
		IpSDisplay.text = "+" + (IpSGain * multiplier).ToString () + " IpS";
	}

	void IncreaseMult (float mult)
	{
		multiplier += mult;
	}
}