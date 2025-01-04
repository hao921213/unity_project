using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightIntensityController : MonoBehaviour
{
    public time1 time1;  // ����ɶ��A�q�{��5��
    public float maxIntensity = 1.0f;  // �̤j���ӱj��
    public float minIntensity = 0.003f;  // �̤p���ӱj��
    private float count;
    private Light2D light2D;
    private float elapsedTime = 0f;
    public int morning = 3;
    public int evening = 18;
    public float change1 = 0.0001f;
    public float change2 = 0.0002f;
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
        if (time1.hour > morning && time1.hour < evening)
        {
            if (light2D.intensity < maxIntensity )
            {
                if (count != time1.count)
                {
                    light2D.intensity = light2D.intensity + change1;
                    count = time1.count;
                }
            }
            
        }
        else if (time1.hour < 24 && time1.hour > evening) 
        {
            if (light2D.intensity > minIntensity)
            {
                light2D.intensity = light2D.intensity - change2;
            }
        }

    }
}
