using UnityEngine;

public class farm1 : MonoBehaviour
{
    public GameObject farm1_controller;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            farm1_controller.SetActive(true);
        }
    }
}
