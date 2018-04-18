using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

    public static UpgradeManager Instance;

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

    public void BuyDeliveryUpgrade(DeliveryUpgrade du)
    {
        print("buy delivery!");
        ScoreManager.Instance.Score -= du.CurrentCost;
        ScoreManager.Instance.UpdateScore();
        du.CurrentCost = 1.15f * du.CurrentCost;

        du.CurrentClickGain = du.CurrentClickGain + du.InitialClickGain;
        ClickManager.Instance.IncreaseClick(du.InitialClickGain);
    }

    public void BuyTransmissionUpgrade(TransmissionUpgrade tu)
    {
        print("buy transmission!");
        ScoreManager.Instance.Score -= tu.CurrentCost;
        ScoreManager.Instance.UpdateScore();
        tu.CurrentCost = 1.15f * tu.CurrentCost;

        tu.CurrentIpSGain = tu.CurrentIpSGain + tu.InitialIpSGain;
        IpSManager.Instance.IncreaseIpS(tu.InitialIpSGain);
    }
}
