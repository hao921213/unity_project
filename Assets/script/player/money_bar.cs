using UnityEngine;
using UnityEngine.UI;

public class money_bar : MonoBehaviour
{
    public player1 player;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text=player.money.ToString();
    }
}
