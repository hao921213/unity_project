using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class animals_grow : MonoBehaviour
{
    public bag farm1;
    public bag farm2;
    public bag farm3;
    public bag farm4;
    public bag farm5;
    public bag farm6;
    public water_controller grow1;
    public water_controller grow2;
    public water_controller grow3;
    public water_controller grow4;
    public water_controller grow5;
    public water_controller grow6;
    public farm_controller farm_controller1;
    public farm_controller farm_controller2;
    public farm_controller farm_controller3;
    public farm_controller farm_controller4;
    public farm_controller farm_controller5;
    public farm_controller farm_controller6;
    public time1 time;
    private int now;
    private bag[] farms=new bag[6];
    private water_controller[] grows=new water_controller[6];
    private farm_controller[] farm_controllers = new farm_controller[6];
    private void Start()
    {
        farms[0] = farm1; grows[0] = grow1; farm_controllers[0] = farm_controller1;
        farms[1] = farm2; grows[1] = grow2; farm_controllers[1] = farm_controller2;
        farms[2] = farm3; grows[2] = grow3; farm_controllers[2] = farm_controller3;
        farms[3] = farm4; grows[3] = grow4; farm_controllers[3] = farm_controller4;
        farms[4] = farm5; grows[4] = grow5; farm_controllers[4] = farm_controller5;
        farms[5] = farm6; grows[5] = grow6; farm_controllers[5] = farm_controller6;
    }
    private void Update()
    {
        if (time.hour != now)
        {
            now = time.hour;
            Update_grow();
        }
        update_delete();
    }
    public void Update_grow() {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++) {
                if (farms[i].itemlist[j]!=null && farms[i].itemlist[j].item_name != "null")
                {   
                    grows[i].waters[j] += 1;
                    if (grows[i].waters[j] > 10)
                    {
                        grows[i].waters[j] = 10;
                    }
                }
                else
                {
                    grows[i].waters[j] = 0;
                }
            }
        }
    }

    public void update_delete()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (farms[i].itemlist[j] == null || farms[i].itemlist[j].item_name == "null")
                {
                    grows[i].waters[j] = 0;
                }
            }
        }
    }
    
}
