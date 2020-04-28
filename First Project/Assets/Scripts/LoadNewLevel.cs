using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewLevel : MonoBehaviour
{
    public string LevelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Application.LoadLevel(LevelToLoad);
        }
    }
}
