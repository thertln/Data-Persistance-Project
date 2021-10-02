using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public InputField usernameInput; // new variable declared
    public Text highscoreText; // new variable declared

    public string username;
    public string highscoreUsername;
    public int highscore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadUsername();
        LoadHigh();

     
    




    }

    [System.Serializable]
    class SaveData
    {
        public string username;
  
    }


    [System.Serializable]
    class HighScore
    {
        public string name;
        public int score;

    }

    public void SaveUsername()
    {
        SaveData data = new SaveData();
        data.username = usernameInput.text;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/username.json", json);
        username = usernameInput.text;
    }

   


    public void LoadUsername()
    {

        string path = Application.persistentDataPath + "/username.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            username = data.username;

            usernameInput.text = username.ToString();
        }


    }



    public void LoadHigh()
    {

        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore data = JsonUtility.FromJson<HighScore>(json);

            highscoreUsername = data.name;
            highscore = data.score;

            highscoreText.text = "Highscore by " + highscoreUsername.ToString() + " :" + highscore.ToString();
        }


    }





}
