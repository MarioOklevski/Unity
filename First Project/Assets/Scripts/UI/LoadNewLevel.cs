using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevel : MonoBehaviour
{
    public string LevelToLoad;
    public string ExitPoint;
    private Controls Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Controls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(LevelToLoad);
            Player.StartPoint = ExitPoint;
        }
    }
}
