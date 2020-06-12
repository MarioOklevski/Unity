using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject m;
    public GameObject s;
    public GameObject b;

    void Start()
    {
        Time.timeScale = 0f;
        m.SetActive(true);
        s.SetActive(false);
        b.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //  MAIN MENU   
    public void Play()
    {
        m.SetActive(false);
        s.SetActive(true);
    }

    public void Settings(){
        // to do
    }

    public void Exit()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    // START MENU
    public void PlayStart()
    {
        s.SetActive(false);
        Time.timeScale = 1f;
        b.SetActive(true);
    } 
    public void Back()
    {
        s.SetActive(false);
        m.SetActive(true);
    }
}
