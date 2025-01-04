using UnityEngine;
using UnityEngine.SceneManagement;

public class forest_Prtal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.tag = "forest_Portal";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene_forest()
    {
        SceneManager.LoadScene("Forest");
    }
}
