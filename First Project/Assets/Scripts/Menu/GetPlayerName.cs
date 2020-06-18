using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerName : MonoBehaviour
{
    private TMP_InputField InputField_Name;
    private static string Name;
    public void Awake()
    {
        InputField_Name = transform.Find("InputField").GetComponent<TMP_InputField>();
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
}
