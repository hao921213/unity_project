using UnityEngine;

public class clerk : MonoBehaviour
{
    public GameObject store_bag;
    private int inplace=0;
    private int has_open=0;
    private void Update()
    {
        trig();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            inplace=1;
            // store_bag.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            inplace=0;
        }
    }
    public void trig(){
        if(inplace==1 && Input.GetKeyDown(KeyCode.E)){
            if(has_open==0){
                store_bag.SetActive(true);
                has_open=1;
            }
            else{
                store_bag.SetActive(false);
                has_open=0;
            }
            
        }
    }
}
