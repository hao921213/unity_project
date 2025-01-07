using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightIntensityController : MonoBehaviour
{
    public time1 time1; 
    public Light2D light2D;
    void Start()
    {
        light2D = GetComponent<Light2D>();
        if (light2D == null)
        {
            Debug.LogError("Light2D component not found on this GameObject.");
        }
    }

    void Update()
    {
        light2D.intensity = time1.intensity;
    }
}
