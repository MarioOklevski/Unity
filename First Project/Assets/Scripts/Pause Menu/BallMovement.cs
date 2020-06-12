using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    GameObject Ball; 
    public string ballName;
    private Rigidbody2D myRigidBody;
    public float moveSpeed=2;
    public int offset=5;
    private Vector3 direction;
    
    public string canvasName;
    private GameObject Canvas ;
    private float CanvasPosX;
    private float CanvasPosY;
    private float CanvasWidth;
    private float CanvasHeight;
    private float BallWidth;
    private float BallHeight;

    private int rx ;
    private int ry;
    public float p=0;
        
    public void Start(){
       
        Ball = GameObject.Find(ballName);
        Canvas = GameObject.Find(canvasName);
     
        getElements();

         rx = Random.Range(0,2);
         ry = Random.Range(0,2);
        if(rx==0)rx=-1;if(ry==0)ry=-1;
        direction= new Vector3(rx* moveSpeed, ry * moveSpeed, 0f);
        // Debug.Log(rx+"==="+ry);
        myRigidBody.velocity = direction;  
   }

    public void Update(){
        // Debug.Log(transform.position);

        float nextX = transform.position.x + myRigidBody.velocity.x;
        float nextY = transform.position.y + myRigidBody.velocity.y;
        //  Debug.Log(nextX+"---"+nextY);

        if ( (nextX - (BallWidth/2-offset) <= 0)|| (nextX + (BallWidth/2-offset) >= CanvasWidth))
        {
           rx=-rx;// myRigidBody.velocity.x = new Vector3(-myRigidBody.velocity.x, myRigidBody.velocity.y, 0f);
        }
        if ((nextY + (BallHeight/2-offset) >= CanvasHeight) || (nextY - (BallHeight/2-offset) <= 0))
        {
            ry=-ry;//myRigidBody.velocity.y = new Vector3(myRigidBody.velocity.x, -myRigidBody.velocity.y, 0f);
        }

        direction= new Vector3(rx* moveSpeed, ry * moveSpeed, 0f);
        myRigidBody.velocity = direction;  
       
        transform.position = new Vector2(transform.position.x+myRigidBody.velocity.x,transform.position.y+myRigidBody.velocity.y);
        Pulse();
        RectTransform ballRectTransform = Ball.GetComponent<RectTransform> ();
        BallWidth=ballRectTransform.rect.width;
        BallHeight=ballRectTransform.rect.height;          
    }

    private void getElements(){
        myRigidBody = GetComponent<Rigidbody2D>();
        // ball
        RectTransform ballRectTransform = Ball.GetComponent<RectTransform> ();
        BallWidth=ballRectTransform.rect.width;
        BallHeight=ballRectTransform.rect.height;                
        // Debug.Log("width: " + ballRectTransform.rect.width + ", height: " + ballRectTransform.rect.height);
        //canvas
        RectTransform canvasRectTransform = Canvas.GetComponent<RectTransform> ();
        CanvasPosX=Canvas.transform.position.x;
        CanvasPosY=Canvas.transform.position.y;
        CanvasWidth=canvasRectTransform.rect.width;
        CanvasHeight=canvasRectTransform.rect.height;
        // Debug.Log("width: " + objectRectTransform.rect.width + ", height: " + objectRectTransform.rect.height);
        // Debug.Log("canvas----"+Canvas.transform.position);

    }

    private void Pulse(){
        if(BallWidth<=20){
            p=0.3f;
        }else if(BallWidth>=50){
            p=-0.3f;
        }
        Ball.GetComponent<RectTransform>().sizeDelta=new Vector2( 1f*(BallWidth+p),1f*(BallHeight+p));
    }

}
