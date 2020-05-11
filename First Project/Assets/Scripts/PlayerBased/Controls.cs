using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float moveSpeed;
    private float CurrentMoveSpeed;
    public float DiagonalMoveModif;
    private Animator anim;
    private Rigidbody2D myRigidBody;
    private bool Moving_Player;
    public Vector2 lastMove;
    private bool Attacking;
    public float AttackTime;
    private float AttackTimeCounter;
    private static bool PlayerExists;
    public string StartPoint;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        if (!PlayerExists)
        {
            PlayerExists = true;
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
        Moving_Player = false;
        if (!Attacking)
        {
            /////////////MOVEMENT/////////////
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * CurrentMoveSpeed, myRigidBody.velocity.y);
                Moving_Player = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * CurrentMoveSpeed);
                Moving_Player = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
            }
            /////////////ATTACK/////////////
            if (Input.GetKeyDown(KeyCode.J))
            {
                AttackTimeCounter = AttackTime;
                Attacking = true;
                myRigidBody.velocity = Vector2.zero;
                anim.SetBool("Attacking", true);
            }
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                CurrentMoveSpeed = moveSpeed * DiagonalMoveModif;
            }
            else
            {
                CurrentMoveSpeed = moveSpeed;
            }

        }
        if(AttackTimeCounter > 0)
        {
            AttackTimeCounter -= Time.deltaTime;
        }
        if(AttackTimeCounter <= 0)
        {
            Attacking = false;
            anim.SetBool("Attacking", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        anim.SetBool("Moving", Moving_Player);
    }
}
