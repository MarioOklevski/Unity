using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyMaxHealth;
    public int EnemyCurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyCurrentHealth <= 0f)
        {
            Destroy(gameObject);
        }
        if(EnemyCurrentHealth > 0f)
        {

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
