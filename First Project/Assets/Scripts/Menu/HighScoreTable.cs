using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class HighScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    private List<Transform> highScoreEntryTransformList;
    private static string PlayerName;
    private static int Score;
    private static bool add=false;

    /// <summary>
    /// Custom Serializable class containing the score and the name of a player entry in the TopScore table
    /// </summary>
    [System.Serializable]
    private class HighScoreEntry{
        public int score;
        public string name;
    }
    /// <summary>
    /// Custom Serializable class containing list of entries for TopScore table
    /// </summary>
    private class HighScores{
        public List<HighScoreEntry> highScoreEntryList;
        public HighScores(){
            highScoreEntryList = new List<HighScoreEntry>();
        }
    }

    private void Awake(){
        highScoreEntryTransformList = new List<Transform>();

        entryTemplate.gameObject.SetActive(false);

        // AddHighScoreEntry(1,"NEW2");//manualy enter

        sort();// FIRST

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores= JsonUtility.FromJson<HighScores>(jsonString);
       //reload table
        //highScores.highScoreEntryList = new List<HighScoreEntry>();
        //string json=JsonUtility.ToJson(highScores);
        //PlayerPrefs.SetString("highScoreTable",json);
        //PlayerPrefs.Save();
       
        

        foreach(HighScoreEntry hse in  highScores.highScoreEntryList){
            CreateEntryTransform(hse,entryContainer,highScoreEntryTransformList);
        }

    }

    // ADD ONE ENTRY
    private void CreateEntryTransform(HighScoreEntry highScoreEntry,Transform entryContainer,List<Transform> transformList){
        float templateHeight = 25f;
        Transform entryTransform = Instantiate(entryTemplate,entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0,-templateHeight*transformList.Count+50);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count+1;
        string rankString;
        switch(rank){
            case 1: rankString="1ST";break;
            case 2: rankString="2ND";break;
            case 3: rankString="3RD";break;
            default: rankString=rank+"TH";break;
        }

        int score = highScoreEntry.score;
        string name = highScoreEntry.name;

        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text =rankString;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);
    }

    public static void AddHighScoreEntry(int Score,string Name){
        /// <summary>
        /// Create new HighScoreEntry
        /// </summary>
        HighScoreEntry highScoreEntry = new HighScoreEntry{score=Score,name=Name};
        /// <summary>
        /// Get JSON list of the table entries
        /// </summary>
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        /// <summary>
        /// Convert to list HighScores
        /// </summary>
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
        /// <summary>
        /// Add new entry to the list
        /// </summary>
        highScores.highScoreEntryList.Add(highScoreEntry);
        /// <summary>
        /// Save updated
        /// </summary>
        string json =JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable",json);
        PlayerPrefs.Save();
    }


    /// <summary>
    /// Sorting on already added entries and saving only the top 5
    /// </summary>
    private void sort(){
        /// <summary>
        /// Get JSON list of the table entries and Convert to list HighScores
        /// </summary>
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
        /// <summary>
        /// Creates the environment to form HighScore table when starting the game for the very first time
        /// </summary>
        if (highScores==null){
            highScores = new HighScores();
            string json=JsonUtility.ToJson(highScores);
            PlayerPrefs.SetString("highScoreTable",json);
            PlayerPrefs.Save();
            return;
        }

        /// <summary>
        /// Sorting the entries from highScoreEntryList based on the score
        /// </summary>
        for (int i=0;i<highScores.highScoreEntryList.Count;i++){
            for (int j=i+1;j<highScores.highScoreEntryList.Count;j++){
                if(highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score){
                    //swap
                    HighScoreEntry tmp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i]=highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j]=tmp;
                }
            }
        }
        /// <summary>
        /// Getting only the top 5 entries and saving them for next usage
        /// </summary>
        if (highScores.highScoreEntryList.Count>5){
            HighScores highScoresNew = new HighScores();
            for (int i=0;i<5;i++){ // just the best 5 at a time
                highScoresNew.highScoreEntryList.Add(highScores.highScoreEntryList[i]);
            }
            string json=JsonUtility.ToJson(highScoresNew);
            PlayerPrefs.SetString("highScoreTable",json); //override
            PlayerPrefs.Save();
        }
    }


    public void SaveScore(){
        // TO DO
        add=false;
        sort();
        PlayerName = GetPlayerName.GetName().ToString();
        Score = ScoreManager.ScoreNumber;
        AddHighScoreEntry(Score, PlayerName);
        sort();
    }
    public static void Add(){
        add=true;
    }
    void Update(){
        if(add){
            SaveScore();
        }
        Awake();
    }
    
}
