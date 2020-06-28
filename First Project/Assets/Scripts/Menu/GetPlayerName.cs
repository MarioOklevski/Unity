using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerName : MonoBehaviour
{
    /*private TMP_InputField InputField_Name;
    private Transform Field;
    public static Text FieldText;
    private static string Name;
    private InputField FieldName;*/

    public GameObject menu;
    static string Name;
    public TMP_InputField Field;
    private static bool killed;

    void Awake()
    {
        killed=false;
        Field.characterLimit = 8;
    }
    public void SetName()
    {
        Name = Field.text;
    }
    public static string GetName()
    {
        return Name;
    }
    public static void BossKilled(){
        killed=true;
    }
    void Update(){
        if(killed){
            ShowHighScore();
        }
    }
    public void ShowHighScore()
    {
        Time.timeScale = 0f;
        Debug.Log("menu"+menu);
        menu.SetActive(true);
        killed=false;
        //gameObject.GetComponent<GetPlayerName>().menu.SetActive(true);
    }
}
