using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // para utilizar system.serializable - class....

public class MainManager_DataPersistance : MonoBehaviour
{
    public static MainManager_DataPersistance Instance;

	public string namePlayer;
    public string PreviousScore = "0";
    public string nameHighScorePlayer;
    public string scoreHighScorePlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighPlayer();
    }

    //Para guardar datos necesitamos una clase, y poner los parámetros que queremos guardar
    [System.Serializable] // Para poder ser transformado la class en JSON
    class SaveData
    {
        public string NameHighPlayer;
        public string HighPlayerScore;
    }

    public void SaveHighPlayer()
    {
        SaveData data = new SaveData();
        data.NameHighPlayer = namePlayer;
        data.HighPlayerScore = PreviousScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadHighPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameHighScorePlayer = data.NameHighPlayer;
            scoreHighScorePlayer = data.HighPlayerScore;
        }
    }
}
