 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyMaxHealth;
    public int EnemyCurrentHealth;
    private PlayerStats Stats;
    public int ExpWhenKilled;
    public int Give_Score;

    
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
                Debug.Log("here");
                HighScoreTable.SaveScore();
                // Menu.KillBoss();
                GameObject button = GameObject.FindGameObjectsWithTag("Btn");button.SetActive(false);
                // slider.SetActive(false);
                // score.SetActive(false);
                // topScore.SetActive(true);

            }
            Destroy(gameObject);
            Stats.AddExperience(ExpWhenKilled);
        }
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
