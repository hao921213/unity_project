using Unity.VisualScripting;
using UnityEngine;

public class water_change : MonoBehaviour
{
    public bag farm1;
    public bag farm2;
    public bag farm3;
    public bag farm4;
    public bag farm5;
    public bag farm6;
    public time1 time;
    public water_controller all_water;
    public item none;
    public farm_controller farm_1;
    public farm_controller farm_2;
    public farm_controller farm_3;
    public farm_controller farm_4;
    public farm_controller farm_5;
    public farm_controller farm_6;
    private int change=0;
    private bag[] farms=new bag[6];
    private farm_controller[] farms_=new farm_controller[6];
    

    private void Start()
    {
        farms[0]=farm1;farms_[0]=farm_1;
        farms[1]=farm2;farms_[1]=farm_2;
        farms[2]=farm3;farms_[2]=farm_3;
        farms[3]=farm4;farms_[3]=farm_4;
        farms[4]=farm5;farms_[4]=farm_5;
        farms[5]=farm6;farms_[5]=farm_6;
    }
    private void Update()
    {
        if(time.count >= 6 && time.count<19 && change==0){
            for(int i=0;i<6;i++){
                if(all_water.waters[i]<=0){
                    for(int j=0;j<farms[i].itemlist.Count;j++){
                        if(farms[i].itemlist[j].item_name!="null"){
                            farms[i].itemlist[j]=none;
                        }
                    }
                    farms_[i].update_animal();
                    continue;
                }
                for(int j=0;j<farms[i].itemlist.Count;j++){
                    if(farms[i].itemlist[j].item_name!="null"){
                        all_water.waters[i]-=(float)farms[j].itemlist[j].water;
                    }
                }
            }
            change=1;
        }
        else if(time.count>20 && change==1){
            change=0;
        }
    }
}
