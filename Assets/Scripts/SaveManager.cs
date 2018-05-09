using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Saves and loads data for levels unlocked and score of each level
/// </summary>
public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public string saveFileName;
    private string saveFilePath;

    //data class to use in JSON methods
    PlayerData data;

    //Player data information
    public float currentScore;
    public float currentClick;
    public float currentIpS;
    public float currentMult;
    public float timeWhenClosed;

    public DeliveryUpgrade[] deliveryUpgrades;
    public TransmissionUpgrade[] transmissionUpgrades;

    //stream writer for editing the text file
    private StreamWriter writer;

    //object that has the levels buttons as children
    /*public Transform LevelsPanel;
    Transform[] LevelsButtons;
    */


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

        data = new PlayerData();

        /*if (LevelsPanel != null)
        {
            LevelsButtons = new Transform[LevelsPanel.childCount];
            for (int i = 0; i < LevelsPanel.childCount; i++)
            {
                LevelsButtons[i] = LevelsPanel.GetChild(i);
            }
        }*/

        saveFilePath =
            Application.persistentDataPath
            + "/" + saveFileName + ".json";
        print(saveFilePath);
    }

    private void Start()
    {
        //loads the progress at the start of the scene
        LoadFromJSON();
    }

    private void Update()
    {
        //TESTING METHOD
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveAsJSON();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadFromJSON();
        }
    }

    /// <summary>
    /// Saves any changes to the player's progress into the text file, using json
    /// </summary>
    public void SaveAsJSON()
    {
        data.currentScore = this.currentScore;
        data.currentClick = this.currentClick;
        data.currentIpS = this.currentIpS;
        data.currentMult = this.currentMult;
        //data.timeWhenClosed = this.timeWhenClosed;

        data.deliveryUpgrades = this.deliveryUpgrades;
        data.transmissionUpgrades = this.transmissionUpgrades;

        // writer = File.CreateText(AssetDatabase.GetAssetPath(file));
        writer = File.CreateText(saveFilePath);
        writer.WriteLine(JsonUtility.ToJson(data));
        writer.Flush();
        writer.Close();

        // AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(file));
    }

    /// <summary>
    /// Reads from the save text file using json and loads the information into the scene
    /// </summary>
    public void LoadFromJSON()
    {
        if (!File.Exists(saveFilePath))
        {
            SaveAsJSON();
        }
        string fileText = System.IO.File.ReadAllText(saveFilePath);
        data = JsonUtility.FromJson<PlayerData>(fileText);

        currentScore = data.currentScore;
        currentClick = data.currentClick;
        currentIpS = data.currentIpS;
        currentMult = data.currentMult;
        //timeWhenClosed = data.timeWhenClosed;

        deliveryUpgrades = new DeliveryUpgrade[data.deliveryUpgrades.Length];
        transmissionUpgrades = new TransmissionUpgrade[data.transmissionUpgrades.Length];

        Array.Copy(data.deliveryUpgrades, this.deliveryUpgrades, deliveryUpgrades.Length);
        Array.Copy(data.transmissionUpgrades, this.transmissionUpgrades, transmissionUpgrades.Length);

        /*if (LevelsPanel != null)
        {
            for (int i = 0; i < LevelsUnlocked.Length; i++)
            {
                //this comparison exists because for serialization, LevelsUnlocked must be an array of int instead of bool
                LevelsButtons[i].GetComponent<LevelButton>().IsUnlocked = LevelsUnlocked[i] == 1 ? true : false;
                LevelsButtons[i].GetComponent<LevelButton>().Score = LevelsScore[i];
                LevelsButtons[i].GetComponent<LevelButton>().UpdateUI();
            }
        }*/
    }

    /// <summary>
    /// Clears all the player's progress and saves to the text file
    /// </summary>
    public void ClearProgress()
    {
        currentScore = 0;
        currentIpS = 0;
        //timeWhenClosed = 0;


        for (int i = 0; i < deliveryUpgrades.Length; i++)
        {
            //deliveryUpgrades[i] = 0;
        }
        for (int i = 0; i < transmissionUpgrades.Length; i++)
        {
            //transmissionUpgrades[i] = 0;
        }

        SaveAsJSON();
    }

    /*public void UnlockLevel(int index)
    {
        if (index < LevelsUnlocked.Length)
        {
            LevelsUnlocked[index] = 1;
            SaveAsJSON();
        }
    }*/

    /*public void SetScore(int index, int score)
    {
        if (score < 0 || score > 3)
        {
            return;
        }
        if (score > LevelsScore[index])
        {
            LevelsScore[index] = score;
            SaveAsJSON();
        }
    }*/
}
