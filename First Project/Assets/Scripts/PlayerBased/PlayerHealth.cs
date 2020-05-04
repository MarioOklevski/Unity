using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerMaxHealth;
    public int PlayerCurrentHealth;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagePlayer(int TakenDamage)
    {
        PlayerCurrentHealth -= TakenDamage;
    }
    public void ResetHealth()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
    }
}
