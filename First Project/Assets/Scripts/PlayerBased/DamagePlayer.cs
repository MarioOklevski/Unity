using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int DamageToDeal;
    private bool reloading;
    public float WaitToReload;
    string SC;
    private GameObject Player;
    public GameObject DamageNumbers;
    // Start is called before the first frame update
    void Start()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        string SC2 = CurrentScene.name;
        SC = SC2;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading)
        {
            WaitToReload -= Time.deltaTime;
            if (WaitToReload <= 0)
            {
                SceneManager.LoadScene(SC);
                Player.GetComponent<PlayerHealth>().ResetHealth();
                Player.SetActive(true);
                reloading = false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().DamagePlayer(DamageToDeal);
            var clone = (GameObject)Instantiate(DamageNumbers, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumbers>().DamageNumber = DamageToDeal;
            if (other.gameObject.GetComponent<PlayerHealth>().PlayerCurrentHealth <= 0)
            {
                Player = other.gameObject;
                other.gameObject.SetActive(false);
                reloading = true;
            }
        }
    }
}
