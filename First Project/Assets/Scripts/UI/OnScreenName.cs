using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenName : MonoBehaviour
{
    public TMP_Text Name;
    // Start is called before the first frame update
    void Start()
    {
        Name.text = GetPlayerName.GetName();
    }
}
