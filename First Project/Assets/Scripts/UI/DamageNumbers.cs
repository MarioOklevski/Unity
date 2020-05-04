using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DamageNumbers : MonoBehaviour
{
    public float MoveSpeed;
    public int DamageNumber;
    public Text DisplayNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayNumber.text = "" + DamageNumber;
        transform.position = new Vector3(transform.position.x, transform.position.y +  (MoveSpeed * Time.deltaTime), transform.position.z);
    }
}
