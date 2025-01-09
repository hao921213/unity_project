using UnityEngine;
using UnityEngine.SceneManagement;

public class bed_Portal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.tag = "bed_Portal";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene_bed()
    {
        SceneManager.LoadScene("bed");
    }
}
