using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int CurrentPlayerLevel;
    public int CurrentPlayerExp;
    public int[] LevelUpExp;
    public int[] HPLevels;
    public int[] AttackLevels;
    public int[] DeffenceLevels;

    private int hp,al,dl;

    public int CurrentHP;
    public int CurrentAttack;
    public int CurrentDeffence;

    public static bool restart=true;

    private PlayerHealth Health;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = HPLevels[1];
        CurrentAttack = AttackLevels[1];
        CurrentDeffence = DeffenceLevels[1];
        hp=CurrentHP;
        al=CurrentAttack;
        dl=CurrentDeffence;
        Health = FindObjectOfType<PlayerHealth>();
        restart=false;
    }
    public static void Reset(){
        restart=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentPlayerExp >= LevelUpExp[CurrentPlayerLevel])
        {
            LevelUp();
        }
        if(restart){
            HPLevels[1]=hp;
            AttackLevels[1]=al;
            DeffenceLevels[1]=dl;
            Health = FindObjectOfType<PlayerHealth>();
            restart=false;
            Debug.Log("heereeee");
        }
    }
    public void AddExperience(int ExpToAdd)
    {
        CurrentPlayerExp += ExpToAdd;
    }
    public void LevelUp()
    {
        CurrentPlayerLevel++;
        CurrentHP = HPLevels[CurrentPlayerLevel];
        CurrentAttack = AttackLevels[CurrentPlayerLevel];
        CurrentDeffence = DeffenceLevels[CurrentPlayerLevel];
        Health.PlayerMaxHealth = CurrentHP;
        Health.PlayerCurrentHealth += CurrentHP - HPLevels[CurrentPlayerLevel - 1];
    }
}
