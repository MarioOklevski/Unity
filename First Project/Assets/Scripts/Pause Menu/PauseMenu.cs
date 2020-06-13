using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuUI;
    public GameObject button;
    public GameObject main;
    public GameObject yesno;


    void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        button.SetActive(true);
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        button.SetActive(false);
        Time.timeScale = 0f;
        Paused = true;
    }
    
    public void QuitGame()
    {
        PauseMenuUI.SetActive(false);
        yesno.SetActive(true);
    }
    
    public void yes(){
        Debug.Log("Quitting game");
        yesno.SetActive(false);
        main.SetActive(true);
        SaveScore();
    }
    public void no(){
        yesno.SetActive(false);
        PauseMenuUI.SetActive(true);
    }


    public void SaveScore(){
        // TO DO
    }
}
