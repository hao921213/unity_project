using UnityEngine;
using UnityEngine.UI;

public class time: MonoBehaviour
{
    public Text text;

    void Update()
    {
        text.text=""+Time.time;
    }
}
