using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Controls : MonoBehaviour
{

    private Animator anim;
    private Vector2 LastMove;
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    private bool Movement;
    public float TimeBetweenMove;
    private float TimeBetweenMoveCounter;
    public float TimeToMove;
    private float TimeToMoveCounter;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        TimeBetweenMoveCounter = TimeBetweenMove;
        TimeToMoveCounter = TimeToMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement)
        {
            TimeToMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = direction;

            if (TimeToMoveCounter < 0f)
            {
                Movement = false;
                TimeBetweenMoveCounter = TimeBetweenMove;
            }
        }
        else
        {
            TimeBetweenMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if (TimeBetweenMoveCounter < 0f)
            {
                Movement = true;
                TimeToMoveCounter = TimeToMove;
                direction = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                LastMove = new Vector2(direction.x, direction.y);
            }
        }
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        anim.SetBool("MovingSkeleton", Movement);
        anim.SetFloat("LastMoveX", LastMove.x);
        anim.SetFloat("LastMoveY", LastMove.y);
    }
}