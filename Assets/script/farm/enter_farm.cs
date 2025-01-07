using UnityEngine;

public class enter_farm : MonoBehaviour
{
    public farm_controller farm1;
    void Start()
    {
        farm1.update_animal();
    }

}
