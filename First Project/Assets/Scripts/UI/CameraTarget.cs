using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 TargetPosition;
    public float CameraSpeed;
    private static bool CameraExists;
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
    }

    // Update is called once per frame
    void Update()
    {
        TargetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, CameraSpeed * Time.deltaTime);
    }
}
