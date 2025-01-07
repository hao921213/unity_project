using UnityEngine;

public class enter_farm : MonoBehaviour
{
    public farm_controller farm1;
    public farm_controller farm2;
    public farm_controller farm3;
    public farm_controller farm4;
    public farm_controller farm5;
    public farm_controller farm6;
    void Start()
    {
        farm1.update_animal();
        farm2.update_animal();
        farm3.update_animal();
        farm4.update_animal();
        farm5.update_animal();
        farm6.update_animal();

    }

}
