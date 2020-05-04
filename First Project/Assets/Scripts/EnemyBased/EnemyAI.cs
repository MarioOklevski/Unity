using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;

    public GameObject Hero;

    private Rigidbody2D Rb;

    public float Movement_speed = 3;

    private Vector2 Movement;
    // Start is called before the first frame update
    void Start()
    {
        Rb = this.GetComponent<Rigidbody2D>();
        Hero = GameObject.Find("Player");
    }

    // Update is called once per frame  
    void Update()
    {
        Vector2 direction = Hero.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg +90;
        Rb.rotation = angle;
        Movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharacter(Movement);
    }
    void moveCharacter(Vector2 direction)
    {
        Rb.MovePosition((Vector2)transform.position + (direction * Movement_speed * Time.deltaTime));
    }
}
