using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class time: MonoBehaviour
{
    public Text text;
    public time1 time1;
    private float count;
    public float maxIntensity = 1.0f;  // �̤j���ӱj��
    public float minIntensity = 0.003f;  // �̤p���ӱj��
    public int morning = 3;         //3.�ܫG
    public int evening = 18;        //18.�ܷt
    public float change1 = 0.0001f; // �����ܱj�t��
    public float change2 = 0.0002f; // �����ܭY�t��
    void Update()
    {
        time1.count+=Time.deltaTime;
        if(time1.count>=24){
            time1.count=0;
            time1.hour+=1;
        }
        if(time1.hour>=24){
            time1.hour=0;
            time1.day+=1;
        }
        text.text=$"Day:{time1.day} Hour:{time1.hour}";

        //���u
        if (time1.hour > morning && time1.hour < evening)
        {
            if (time1.intensity < maxIntensity)
            {
                if (count != time1.count)
                {
                    time1.intensity = time1.intensity + change1;
                    count = time1.count;
                }
            }
        }
        else if (time1.hour < 24 && time1.hour > evening)
        {
            if (time1.intensity > minIntensity)
            {
                time1.intensity = time1.intensity - change2;
            }
        }
    }
}
