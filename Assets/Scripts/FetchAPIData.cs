using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using TMPro;
public class FetchAPIData : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;  
    public TextMeshProUGUI playerLevelText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerPositionText;
    public TextMeshProUGUI playerInventoryText;

    private void Start()
    {
        StartCoroutine(fetchData("https://api.jsonbin.io/v3/b/6686a992e41b4d34e40d06fa"));
    }
    IEnumerator fetchData(string url)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = request.downloadHandler.text;
                AllWebData data = JsonUtility.FromJson<AllWebData>(json);
                DisplayData(data.record);
                
            }
        }
    }
    [System.Serializable]
    public class Inventory
    {
        public string itemName;
        public int quantity;
        public double weight;
    }

    [System.Serializable]
    public class Position
    {
        public int x;
        public int y;
        public int z;
    }
    [System.Serializable]
    public class Player
    {
        public string playerName;
        public int level;
        public double health;
        public Position position;
        public List<Inventory> inventory;
    }

    [System.Serializable]
    public class Metadata
    {
        public string id;
        public bool @private;
        public string createdAt;
        public string name;
    }

    [System.Serializable]
    public class AllWebData
    {
        public Player record;
        public Metadata metadata;
  
    }

    void DisplayData(Player record)
    {
        playerNameText.text = $"Name: {record.playerName}";
        playerLevelText.text = $"Level: {record.level}";
        playerHealthText.text = $"Health: {record.health}";
        playerPositionText.text = $"Position: (X: {record.position.x}, Y: {record.position.y}, Z: {record.position.z})";

        playerInventoryText.text = "Inventory:";
        foreach (var item in record.inventory)
        {
            playerInventoryText.text += $"\n- {item.itemName} (Qty: {item.quantity}, Weight: {item.weight})";
        }
    }

}
