using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public int Damage;
    public GameObject DamageEffect;
    public GameObject DamageNumbers;
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
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().DamageEnemy(Damage);
            Instantiate(DamageEffect, transform.position, transform.rotation);
            var clone = (GameObject)Instantiate(DamageNumbers, transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumbers>().DamageNumber = Damage;
        }
    }
}
