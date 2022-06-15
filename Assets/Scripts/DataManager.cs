using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public int score;

    public void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class BestPlayerData
    {
        public string playerName;
        public int score;
    }

    public void SaveData()
    {
        BestPlayerData player = new BestPlayerData();
        player.playerName = playerName;
        player.score = score;

        string json = JsonUtility.ToJson(player);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlayerData player = JsonUtility.FromJson<BestPlayerData>(json);

            playerName = player.playerName;
            score = player.score;
        }
    }
}
