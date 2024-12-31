using UnityEngine;

[CreateAssetMenu(fileName = "new_item", menuName = "bag/new_item")]
public class item : ScriptableObject
{
    public string item_name;
    public Sprite item_image;
    public int held;
}
