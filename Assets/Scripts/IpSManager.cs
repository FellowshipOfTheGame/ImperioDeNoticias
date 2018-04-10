using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpSManager : MonoBehaviour {

	[SerializeField] [Range(0, 1)] private float era = 0.01f;
	[SerializeField] private float IpSGain;
	[SerializeField] private ScoreManager SM;

	private float time;

	private void Start()
	{
		time = 0;
	}

	void Update () 
	{
		time += Time.deltaTime;

		if (time >= era)
		{
			SM.UpdateScore (IpSGain * era);
		}
	}
}
