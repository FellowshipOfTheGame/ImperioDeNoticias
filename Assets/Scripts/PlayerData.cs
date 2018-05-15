using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{

    public float currentScore;
    public float currentClick;
    public float currentIpS;
    public float currentMult;
    public float timeWhenClosed;

    public DeliveryUpgrade[] deliveryUpgrades;
    public TransmissionUpgrade[] transmissionUpgrades;

}
