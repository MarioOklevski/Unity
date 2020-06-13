using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreTable : MonoBehaviour
{
   public Transform entryContainer;
   public Transform entryTemplate;
   private List<Transform> highScoreEntryTransformList;

// PRIVATE CLASSES X2   
    [System.Serializable]
    private class HighScoreEntry{
        public int score;
        public string name;
    }
    private class HighScores{
        public List<HighScoreEntry> highScoreEntryList;
        public HighScores(){
            highScoreEntryList = new List<HighScoreEntry>();
        }
    }

    public void Awake(){
        highScoreEntryTransformList = new List<Transform>();

        entryTemplate.gameObject.SetActive(false);

        // AddHighScoreEntry(1000,"NEW");//manualy enter

        sort();// FIRST

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

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

    public void AddHighScoreEntry(int score,string name){
        // create
        HighScoreEntry highScoreEntry = new HighScoreEntry{score=score,name=name};
        //load-get
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
        //add new entry
        highScores.highScoreEntryList.Add(highScoreEntry);
        //save updated
        string json=JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable",json);
        PlayerPrefs.Save();
        // Debug.Log(PlayerPrefs.GetString("highScoreTable"));
    }

    private void sort(){
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        //sort 
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
        if(highScores.highScoreEntryList.Count>5){
            HighScores highScoresNew = new HighScores();
            for (int i=0;i<5;i++){ // just the best 5 at a time
                highScoresNew.highScoreEntryList.Add(highScores.highScoreEntryList[i]);
            }
            string json=JsonUtility.ToJson(highScoresNew);
            PlayerPrefs.SetString("highScoreTable",json); //override
            PlayerPrefs.Save();
        }
    }
    
}
