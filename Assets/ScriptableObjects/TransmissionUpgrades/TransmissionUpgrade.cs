using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Transmission", menuName = "Upgrades/Transmission", order = 2)]
public class TransmissionUpgrade : ScriptableObject {

    public float InitialCost;
    public float InitialIpSGain;

    public float CurrentCost;
    public float CurrentIpSGain;

    private void Awake()
    {
        CurrentCost = InitialCost;
        CurrentIpSGain = InitialIpSGain;
    }
}
