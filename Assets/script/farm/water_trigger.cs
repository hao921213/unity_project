using UnityEngine;

public class water_trigger : MonoBehaviour
{
    public GameObject panel;
    private int player_in=0;
    private int open=0;

    private void Update()
    {
        if(player_in==1 && Input.GetKeyDown(KeyCode.E)){
            if(open==0){
                panel.SetActive(true);
                open=1;
            }
            else{
                panel.SetActive(false);
                open=0;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            player_in=1;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            player_in=0;
        }
    }
}
