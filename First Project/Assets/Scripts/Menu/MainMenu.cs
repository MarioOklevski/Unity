using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    }
    public void Random(){
        SceneManager.LoadScene("Begining");
    }

    public void SceneToChange(string scene)
    {
       SceneManager.LoadScene(scene);
    }

    public void ExitGame(){
        Debug.Log("EXIT");
        Application.Quit();
    }

}
 