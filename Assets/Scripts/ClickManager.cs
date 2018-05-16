using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

    public static ClickManager Instance;

    [SerializeField] private float ClickGain;

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

    public void Click()
    {
        ScoreManager.Instance.UpdateScore(ClickGain);
    }

    public void IncreaseClick(float value)
    {
        ClickGain += value;
        SaveManager.Instance.currentClick = ClickGain;
    }
}
