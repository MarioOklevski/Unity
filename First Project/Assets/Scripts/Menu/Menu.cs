using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public GameObject main;
    public GameObject start;
    public GameObject button;
    public GameObject ball;
    public GameObject slider;
    public GameObject player;
    public GameObject yesno;
    public GameObject info;
    public GameObject topScore;
    public GameObject scoreBoard;
    public GameObject canvas;
    private static bool ConfirmReset = false;
    private SpriteRenderer sp;



    public void Start()
    {
        sp=player.GetComponent<SpriteRenderer>();
        sp.color = new Color(1f,1f,1f,0f);
        Time.timeScale = 0f;
        main.SetActive(true);
        ball.SetActive(true);
        start.SetActive(false);
        button.SetActive(false);
        slider.SetActive(false);
        yesno.SetActive(false);
        info.SetActive(false);
        topScore.SetActive(false);
        scoreBoard.SetActive(false);


    }
     public void KillBoss()
    {
        sp=player.GetComponent<SpriteRenderer>();
        sp.color = new Color(1f,1f,1f,0f);
        Time.timeScale = 0f;
        main.SetActive(true);
        ball.SetActive(true);
        start.SetActive(false);
        button.SetActive(false);
        slider.SetActive(false);
        yesno.SetActive(false);
        info.SetActive(false);
        topScore.SetActive(false);
        scoreBoard.SetActive(false);
    }
    //  MAIN MENU   
    public void Play()
    {
        main.SetActive(false);
        start.SetActive(true);
    }

    public void Info(){
        main.SetActive(false);
        info.SetActive(true);
    }
    public void TopScore(){
        main.SetActive(false);
        topScore.SetActive(true);
    }
   

    public void Exit()
    {
        main.SetActive(false);
        yesno.SetActive(true);
    }
       public void yes(){
        yesno.SetActive(false);
        Debug.Log("Quitting game");
        Application.Quit();
    }
    public void no(){
        yesno.SetActive(false);
        main.SetActive(true);
    }

    // START MENU
    public void PlayStart()
    {
        start.SetActive(false);
        Time.timeScale = 1f;
        ball.SetActive(false);
        button.SetActive(true);
        slider.SetActive(true);
        scoreBoard.SetActive(true);
        topScore.SetActive(false);

        sp=player.GetComponent<SpriteRenderer>();
        sp.color = new Color(1f,1f,1f,1f);


    } 

    public void Back()
    {
        if(SceneManager.GetActiveScene().name =="BOSS_LEVEL"){
            PlayerStats.Reset();
            PlayerStartPoint.Reset();
            ScoreManager.SetScore();
            SceneManager.LoadScene("Begining");
            player.GetComponent<Controls>().StartPoint = "Begin";
            canvas.GetComponent<PlayerStats>().CurrentPlayerLevel = 0;
            canvas.GetComponent<PlayerStats>().CurrentPlayerExp = 0;
            player.GetComponent<PlayerHealth>().PlayerCurrentHealth = 50;
            Start();
            

        }else{
            info.SetActive(false);
            topScore.SetActive(false);
            start.SetActive(false);
            main.SetActive(true);
        }
    }

    public static void ConfirmResetSet()
    {
        ConfirmReset = true;
    }

    private void Update()
    {
        if (ConfirmReset)
        {
            PlayerStats.Reset();
            PlayerStartPoint.Reset();
            ScoreManager.SetScore();
            SceneManager.LoadScene("Begining");
            player.GetComponent<Controls>().StartPoint = "Begin";
            canvas.GetComponent<PlayerStats>().CurrentPlayerLevel = 0;
            canvas.GetComponent<PlayerStats>().CurrentPlayerExp = 0;
            player.GetComponent<PlayerHealth>().PlayerCurrentHealth = 50;
            Start();

            ConfirmReset = false;
        }
    }
}
