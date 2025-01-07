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
    private int[] change=new int[6];

    private void Update()
    {
        if(time.count>=6 && time.count<19 && change[0]==0){
            for(int i=0;i<farm1.itemlist.Count;i++){
                if(farm1.itemlist[i].item_name!="null"){
                    all_water.waters[0]-=(float)farm1.itemlist[i].water;
                }
            }
            change[0]=1;
        }
        else if(time.count>20 && change[0]==1){
            change[0]=0;
        }

                if(time.count>=6 && time.count<19 && change[1]==0){
            for(int i=0;i<farm2.itemlist.Count;i++){
                if(farm2.itemlist[i].item_name!="null"){
                    all_water.waters[2]-=(float)farm2.itemlist[i].water;
                }
            }
            change[1]=1;
        }
        else if(time.count>20 && change[1]==1){
            change[1]=0;
        }

                if(time.count>=6 && time.count<19 && change[2]==0){
            for(int i=0;i<farm3.itemlist.Count;i++){
                if(farm3.itemlist[i].item_name!="null"){
                    all_water.waters[3]-=(float)farm3.itemlist[i].water;
                }
            }
            change[2]=1;
        }
        else if(time.count>20 && change[2]==1){
            change[2]=0;
        }

                if(time.count>=6 && time.count<19 && change[3]==0){
            for(int i=0;i<farm4.itemlist.Count;i++){
                if(farm4.itemlist[i].item_name!="null"){
                    all_water.waters[3]-=(float)farm4.itemlist[i].water;
                }
            }
            change[3]=1;
        }
        else if(time.count>20 && change[3]==1){
            change[3]=0;
        }

                if(time.count>=6 && time.count<19 && change[4]==0){
            for(int i=0;i<farm5.itemlist.Count;i++){
                if(farm5.itemlist[i].item_name!="null"){
                    all_water.waters[4]-=(float)farm5.itemlist[i].water;
                }
            }
            change[4]=1;
        }
        else if(time.count>20 && change[4]==1){
            change[4]=0;
        }

                if(time.count>=6 && time.count<19 && change[5]==0){
            for(int i=0;i<farm6.itemlist.Count;i++){
                if(farm6.itemlist[i].item_name!="null"){
                    all_water.waters[5]-=(float)farm6.itemlist[i].water;
                }
            }
            change[5]=1;
        }
        else if(time.count>20 && change[5]==1){
            change[5]=0;
        }
    }
}
