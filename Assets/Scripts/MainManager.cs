using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string PlayerName;
    public int HighScore;
    public string HighScorePlayerName;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
        public string highScorePlayerName;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = PlayerName;
        data.highScore = HighScore;
        data.highScorePlayerName = HighScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(
            Application.persistentDataPath + "/savefile.json",
            json
        );
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.highScore;
            HighScorePlayerName = data.highScorePlayerName;
        }

    }
}
