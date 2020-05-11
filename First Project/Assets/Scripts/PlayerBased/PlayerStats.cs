using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int CurrentPlayerLevel;
    public int CurrentPlayerExp;
    public int[] LevelUpExp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentPlayerExp >= LevelUpExp[CurrentPlayerLevel])
        {
            CurrentPlayerLevel++;
        }
    }
    public void AddExperience(int ExpToAdd)
    {
        CurrentPlayerExp += ExpToAdd;
    }
}
