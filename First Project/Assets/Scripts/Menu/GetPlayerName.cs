using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetPlayerName : MonoBehaviour
{
    private TMP_InputField InputField_Name;
    private Transform Field;
    public GameObject ScoreMenu;
    private static string Name;
    void Awake()
    {
        ScoreMenu = GameObject.Find("TopScore Menu");
        Field = transform.Find("InputField");
        InputField_Name = Field.GetComponent<TMP_InputField>();
        SetName();
    }
    public void SetName()
    {
        Name = InputField_Name.text;
    }
    public static string GetName()
    {
        return Name;
    }
    public static void ShowHighScore()
    {
        Time.timeScale = 0f;
        ScoreMenu.SetActive(true);
    }
}
