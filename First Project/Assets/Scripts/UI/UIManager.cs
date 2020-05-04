using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Slider HPBar;
    public Text HPText;
    public PlayerHealth PlayerHP;
    private static bool UIExists;
    // Start is called before the first frame update
    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.maxValue = PlayerHP.PlayerMaxHealth;
        HPBar.value = PlayerHP.PlayerCurrentHealth;
        HPText.text = "HP:" + PlayerHP.PlayerCurrentHealth + "/" + PlayerHP.PlayerMaxHealth; 
    }
}
