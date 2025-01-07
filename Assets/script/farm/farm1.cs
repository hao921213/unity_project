using UnityEngine;

public class farm1 : MonoBehaviour
{
    public GameObject farm1_controller;
    private int enter=0;
    private int open=0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            enter=1;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            farm1_controller.SetActive(false);
            enter=0;
        }
    }

    private void Update()
    {
        if(enter==1 && Input.GetKeyDown(KeyCode.E)){
            if(open==0 ){
                farm1_controller.SetActive(true);
                open=1;
            }
            else{
                farm1_controller.SetActive(false);
                open=0;
            }
        }
    }
}
