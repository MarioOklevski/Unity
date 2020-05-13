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

    public int CurrentHP;
    public int CurrentAttack;
    public int CurrentDeffence;

    private PlayerHealth Health;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = HPLevels[1];
        CurrentAttack = AttackLevels[1];
        CurrentDeffence = DeffenceLevels[1];
        Health = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentPlayerExp >= LevelUpExp[CurrentPlayerLevel])
        {
            LevelUp();
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
