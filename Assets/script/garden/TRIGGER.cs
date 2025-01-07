using UnityEngine;
using UnityEngine.UI;

public class TRIGGER : MonoBehaviour
{
    public GameObject Controller;
    private int enter = 0;
    private int open = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enter = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Controller.SetActive(false);
            enter = 0;
        }
    }

    private void Update()
    {
        if (enter == 1 && Input.GetKeyDown(KeyCode.E))
        {
            if (open == 0)
            {
                Controller.SetActive(true);
                open = 1;
            }
            else
            {
                Controller.SetActive(false);
                open = 0;
            }
        }
    }
}
