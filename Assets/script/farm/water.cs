using UnityEngine;
using UnityEngine.UI;

public class water : MonoBehaviour
{
    public water_controller all_water;
    public Scrollbar scrollbar;
    public Text text;
    public int index;
    public float maxWater=50;
    private void Update()
    {
        update_water();
    }
    public void update_water(){
        float water=all_water.waters[index];
        scrollbar.value = Mathf.Clamp01(water / maxWater);
        text.text=water.ToString()+"/50";
    }
}
