 using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyMaxHealth;
    public int EnemyCurrentHealth;
    private PlayerStats Stats;
    public int ExpWhenKilled;
    public int Give_Score;
    private GameObject Button;
    private GameObject Slider;
    private GameObject Score;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        Stats = FindObjectOfType<PlayerStats>();
        EnemyCurrentHealth = EnemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyCurrentHealth <= 0f)
        {
            
            ScoreManager.ScoreNumber += Give_Score;
            if(gameObject.tag == "Boss")
            {
                Time.timeScale = 0f;
                CallTopScoreMenu();
            }
            Destroy(gameObject);
            Stats.AddExperience(ExpWhenKilled);
        }
    }
    public void CallTopScoreMenu()
    {
        Debug.Log("here");
        GetPlayerName.BossKilled();
        //HighScoreTable.SaveScore();
        // Menu.KillBoss();
        Button = GameObject.Find("Button Pause");
        Button.SetActive(false);
        Slider = GameObject.Find("Slider");
        Slider.SetActive(false);
        //Score = GameObject.Find("TopScore Menu");
        //Score.SetActive(true);
        //topScore.SetActive(true);
    }
    public void DamageEnemy(int TakenDamage)
    {
        EnemyCurrentHealth -= TakenDamage;
    }
    public void ResetHealth()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
    }
}
