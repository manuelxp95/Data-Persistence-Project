using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public string playerName;
    public static MenuUI Instance;
    public string NameScore;
    public TextMeshProUGUI scoreText;
    public int higherScore = 0;

    
    private void Awake()
    {   
        scoreText =GameObject.Find("/Canvas/Panel/ScoreText").GetComponent<TextMeshProUGUI>();
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inputName(string inputPlayer){
        MenuUI.Instance.playerName= inputPlayer;
    }

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    //---------------------Save scores-------------------
    public void Exit()
    {
        
        //MenuUI.Instance.SaveScore();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
    
    [System.Serializable]
    class SaveData
    {
        public string NameScore;
        public int BestScore;
    }
    
    public void SaveScore(int bScore)
    {
        if (higherScore <= bScore){
            SaveData data = new SaveData();

            // Add score variables
            data.NameScore = MenuUI.Instance.playerName;
            higherScore= bScore;
            data.BestScore = bScore;
        
            string json = JsonUtility.ToJson(data);
  
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);


            // Add score variables
            NameScore = data.NameScore;
            higherScore = data.BestScore;
            scoreText.text="Best Score: " + NameScore + " " + higherScore;
        }
    }


}
