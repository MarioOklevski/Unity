using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerMaxHealth;
    public int PlayerCurrentHealth;
    public float WaitToReload;
    string SC;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        string SC2 = CurrentScene.name;
        SC = SC2;
        PlayerCurrentHealth = PlayerMaxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCurrentHealth <= 0f)
        {
            gameObject.SetActive(false);
            WaitToReload -= Time.deltaTime;
            if (WaitToReload <= 0f)
            {
            SceneManager.LoadScene(SC);
            gameObject.SetActive(true);
            }
        }
            /*if (reloading)
            {
                WaitToReload -= Time.deltaTime;
                if (WaitToReload <= 0f)
                {
                    SceneManager.LoadScene(SC);
                    gameObject.SetActive(true);
                    reloading = false;
                }
            }
            if(WaitToReload <= 0)
            {
                reloading = false;
            }*/
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
