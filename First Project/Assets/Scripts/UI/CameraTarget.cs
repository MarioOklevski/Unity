using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 TargetPosition;
    public float CameraSpeed;
    private static bool CameraExists;
    public BoxCollider2D BoundsBox;
    private Vector3 MinBounds;
    private Vector3 MaxBounds;
    private Camera Camera;
    private float HalfHeight;
    private float HalfWidth;
    // Start is called before the first frame update
    void Start()
    {
        if (!CameraExists)
        {
            CameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        MinBounds = BoundsBox.bounds.min;
        MaxBounds = BoundsBox.bounds.max;
        Camera = GetComponent<Camera>();
        HalfHeight = Camera.orthographicSize;
        HalfWidth = HalfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(BoundsBox = null)
        {
            BoundsBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
            MinBounds = BoundsBox.bounds.min;
            MaxBounds = BoundsBox.bounds.max;
        }

        TargetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, CameraSpeed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, MinBounds.x + HalfWidth, MaxBounds.x - HalfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, MinBounds.y + HalfHeight, MaxBounds.y - HalfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
    public void SetBounds(BoxCollider2D NewBounds)
    {
        BoundsBox = NewBounds;
        MinBounds = BoundsBox.bounds.min;
        MaxBounds = BoundsBox.bounds.max;
    }
}
