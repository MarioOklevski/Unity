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
    public GameObject slider;
    public GameObject player;
    private SpriteRenderer sp;
    void Start()
    {
      
        sp=player.GetComponent<SpriteRenderer>();
        sp.color = new Color(1f,1f,1f,0f);
        Time.timeScale = 0f;
        m.SetActive(true);
        s.SetActive(false);
        b.SetActive(false);
        slider.SetActive(false);
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
        slider.SetActive(true);
         sp=player.GetComponent<SpriteRenderer>();
        sp.color = new Color(1f,1f,1f,1f);
    } 
    public void Back()
    {
        s.SetActive(false);
        m.SetActive(true);
    }
}
