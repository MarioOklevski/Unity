using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreTable : MonoBehaviour
{
   public Transform entryContainer;
   public Transform entryTemplate;
   private List<HighScoreEntry> highScoreEntryList;
   private List<Transform> highScoreEntryTransformList;

    private class HighScoreEntry{
        public int score;
        public string name;
    }
    public void Awake(){

        entryTemplate.gameObject.SetActive(false);

        highScoreEntryList = new List<HighScoreEntry>(){
            new HighScoreEntry{score=54321,name="aaa"},
            new HighScoreEntry{score=125,name="aaa"},
            new HighScoreEntry{score=124,name="aaa"},
            new HighScoreEntry{score=123,name="aaa"}
        };
        highScoreEntryTransformList = new List<Transform>();

        foreach(HighScoreEntry hse in  highScoreEntryList){
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

    // public void Awake(){

    //     entryTemplate.gameObject.SetActive(false);

    //     float templateHeight = 25f;
    //     for(int i=0;i<5;i++){
    //         Transform entryTransform = Instantiate(entryTemplate,entryContainer);
    //         RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
    //         entryRectTransform.anchoredPosition = new Vector2(0,-templateHeight*i+50);
    //         entryTransform.gameObject.SetActive(true);

    //         int rank = i+1;
    //         string rankString;
    //         switch(rank){
    //             case 1: rankString="1ST";break;
    //             case 2: rankString="2ND";break;
    //             case 3: rankString="3RD";break;
    //             default: rankString=rank+"TH";break;
    //         }
    //         int score = Random.Range(0,1000);
    //         string name = "aaa";

    //         entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text =rankString;
    //         entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
    //         entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

    //     }
    // }
}
