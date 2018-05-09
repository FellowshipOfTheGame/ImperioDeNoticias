using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IpSManager : MonoBehaviour {

    public static IpSManager Instance;

	[SerializeField] [Range(0, 1)] private float era = 0.01f;
	[SerializeField] private float IpSGain;
	[SerializeField] private float IpSMultiplier;
	[SerializeField] private Text IpSDisplay;

	private float time;

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

    private void Start()
	{
		time = 0;
		IpSDisplay.text = "+0 IpS";
	}

	void Update () 
	{
		time += Time.deltaTime;

		if (time >= era)
		{
			ScoreManager.Instance.UpdateScore (IpSGain * IpSMultiplier * era);
		}
	}

	public void IncreaseIpS (float value) 
	{
		IpSGain += value;
        SaveManager.Instance.currentIpS = IpSGain;
		IpSDisplay.text = "+" + (IpSGain * IpSMultiplier).ToString () + " IpS";

	}

	public void IncreaseMult (float mult)
	{
		IpSMultiplier += mult;
        SaveManager.Instance.currentMult = IpSMultiplier;
    }
}