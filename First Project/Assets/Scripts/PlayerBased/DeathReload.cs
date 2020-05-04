using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathReload : MonoBehaviour
{
    public float WaitToReload;
    string SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        string SceneName = CurrentScene.name;
        SceneToLoad = SceneName;
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
