using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private BoxCollider2D TheBounds;
    private CameraTarget Camera;
    // Start is called before the first frame update
    void Start()
    {
        TheBounds = GetComponent<BoxCollider2D>();
        Camera = FindObjectOfType<CameraTarget>();
        Camera.SetBounds(TheBounds);
    }

    // Update is called once per frame
}
