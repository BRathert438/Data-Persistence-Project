using UnityEngine;
using System.IO;

public class SessionManager : MonoBehaviour
{

    public static SessionManager Instance;

    public string playerName;
    public int playerScore;

    private void Awake()
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
    class SaveData
    {

        public string highScoreName;
        public int highScorePoints;

    }

    public void SaveHighScore()
    {

        SaveData data = new SaveData();

        data.highScoreName = playerName;
        data.highScorePoints = playerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadHighScore()
    {

        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {

            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.highScoreName;
            playerScore = data.highScorePoints;
            
        }

    }

}
