using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int ScoreNumber = 0;
    Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + ScoreNumber;
    }
    public void AddScore(int ScoreToAdd)
    {
        ScoreNumber += ScoreToAdd;
    }
    public static void SetScore(){
        ScoreNumber=0;
    }
}
