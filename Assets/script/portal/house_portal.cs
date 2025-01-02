using UnityEngine;
using UnityEngine.SceneManagement;

public class house_portal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.tag = "house_Portal";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene_house()
    {
        SceneManager.LoadScene("Home");
    }
}
