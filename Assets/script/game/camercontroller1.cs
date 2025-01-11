using UnityEngine;

public class cameracontroller1 : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 0, -10f); 

    private Camera cam;
    private float camHalfHeight; 
    private float camHalfWidth;  

    void Start()
    {
        cam = Camera.main;

        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.orthographicSize * cam.aspect;
    }

    void LateUpdate()
    {

        Vector3 rawTargetPosition = target.position + offset;

        transform.position= rawTargetPosition;
    }
}
