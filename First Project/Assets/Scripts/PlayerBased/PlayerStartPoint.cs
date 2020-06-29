using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private Controls Player;
    private CameraTarget Camera;
    public Vector2 StartDirection;
    public string PointName;
    public static bool restart=true;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Controls>();
        if(Player.StartPoint == PointName)
        {
            Player.transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z);
            Player.lastMove = StartDirection;

            Camera = FindObjectOfType<CameraTarget>();
            Camera.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.transform.position.z);
        }
        restart=false;
        
    }
    // Update is called once per frame
    void Update()
    {
         if(restart){
            Start();
        }
    }
    public static void Reset(){
        restart=true;
    }
}
