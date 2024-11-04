using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    void Start()
    {
        SaveData();
        LoadData();
    }

    void Update()
    {
        
    }
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int score;
        public int[] levelsCompleted;
    }

    PlayerData playerData = new PlayerData
    {
        playerName = "Junior",
        score = 100,
        levelsCompleted = new int[] { 1, 2, 3, 4, 5 }
    };

    // Save Data by serializing it
    void SaveData()
    {
        string json = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText("playerdata.json", json);
    }

    // Retrieving data

    void LoadData()
    {
        string json = System.IO.File.ReadAllText("playerdata.json");
        PlayerData loadedPlayer = JsonUtility.FromJson<PlayerData>(json);

        // Display the data
        Debug.Log(loadedPlayer.playerName);
        Debug.Log(loadedPlayer.score);
        Debug.Log(loadedPlayer.levelsCompleted);
    }

}
