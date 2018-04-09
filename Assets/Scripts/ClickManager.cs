using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

    public float ClickGain;

    public ScoreManager SM;

    private void Start()
    {
        print("Start");

    }

    public void Click()
    {
        print("Click");
        SM.UpdateScore(ClickGain);
    }
}
