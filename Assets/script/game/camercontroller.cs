using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 0, -10f); 
    public BoxCollider2D sceneBounds; 

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
        if (target == null || sceneBounds == null)
        {
            Debug.LogError("Target or SceneBounds is not assigned!");
            return;
        }

        
        Vector3 rawTargetPosition = target.position + offset;

       
        float minX = sceneBounds.bounds.min.x + camHalfWidth;
        float maxX = sceneBounds.bounds.max.x - camHalfWidth;
        float minY = sceneBounds.bounds.min.y + camHalfHeight;
        float maxY = sceneBounds.bounds.max.y - camHalfHeight;

        
        float clampedX = Mathf.Clamp(rawTargetPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(rawTargetPosition.y, minY, maxY);

        
        transform.position = new Vector3(clampedX, clampedY, rawTargetPosition.z);
    }
}
