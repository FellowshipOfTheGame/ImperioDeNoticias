using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour {

    public enum UpgradeType
    {
        DELIVERY,
        TRANSMISSION
    }

    public DeliveryUpgrade du;
    public TransmissionUpgrade tu;

    public UpgradeType upgradeType;

    private Button Button;

    public void Start()
    {
        Button = transform.GetChild(2).GetComponent<Button>();
    }

    public void Update()
    {
        if(upgradeType == UpgradeType.DELIVERY)
        {
            CheckScoreDelivery();
        }
        else
        {
            CheckScoreTransmission();
        }
    }

    public void CheckScoreDelivery()
    {
        if(ScoreManager.Instance.Score < du.CurrentCost)
        {
            Button.interactable = false;
        }
        else
        {
            Button.interactable = true;
        }
    }

    public void CheckScoreTransmission()
    {
        if (ScoreManager.Instance.Score < tu.CurrentCost)
        {
            Button.interactable = false;
        }
        else
        {
            Button.interactable = true;
        }
    }

    public void ResetDelivery()
    {
        du.CurrentCost = du.InitialCost;
        du.CurrentClickGain = du.InitialClickGain;
    }

    public void ResetTransmission()
    {
        tu.CurrentCost = tu.InitialCost;
        tu.CurrentIpSGain = tu.InitialIpSGain;
    }
}
