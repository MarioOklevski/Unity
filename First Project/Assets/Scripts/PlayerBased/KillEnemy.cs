using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public int Damage;
    private int CurrentDamage;
    public GameObject DamageEffect;
    public GameObject DamageNumbers;
    private PlayerStats Stats;
    // Start is called before the first frame update
    void Start()
    {
        Stats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            CurrentDamage = Damage + Stats.CurrentAttack;
            collision.gameObject.GetComponent<EnemyHealth>().DamageEnemy(CurrentDamage);
            Instantiate(DamageEffect, transform.position, transform.rotation);
            var clone = (GameObject)Instantiate(DamageNumbers, transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumbers>().DamageNumber = CurrentDamage;
        }
    }
}
