using UnityEngine;
using UnityEngine.SceneManagement;

public class farm_Portal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.tag = "farm_Portal";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene_farm()
    {
        SceneManager.LoadScene("farm");
    }
}
