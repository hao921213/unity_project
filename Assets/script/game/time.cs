using UnityEngine;
using UnityEngine.UI;

public class time: MonoBehaviour
{
    public Text text;
    public time1 time1;

    void Update()
    {
        time1.count+=Time.deltaTime;
        if(time1.count>=6){
            time1.count=0;
            time1.hour+=1;
        }
        if(time1.hour>=24){
            time1.hour=0;
            time1.day+=1;
        }
        text.text=$"Day:{time1.day} Hour:{time1.hour}";
    }
}
