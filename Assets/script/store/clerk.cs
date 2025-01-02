using UnityEngine;

public class clerk : MonoBehaviour
{
    public GameObject store_bag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            store_bag.SetActive(true);
        }
    }
}
