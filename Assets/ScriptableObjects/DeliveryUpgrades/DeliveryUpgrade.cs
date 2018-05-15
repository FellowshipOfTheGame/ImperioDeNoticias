using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Delivery", menuName = "Upgrades/Delivery", order = 1)]
public class DeliveryUpgrade : ScriptableObject {

    public int InitialCost;
    public float InitialClickGain;

    public float CurrentCost;
    public float CurrentClickGain;

    private void Awake()
    {
        CurrentCost = InitialCost;
        CurrentClickGain = InitialClickGain;
    }
}
