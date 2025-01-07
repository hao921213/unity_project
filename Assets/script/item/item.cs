using UnityEngine;

[CreateAssetMenu(fileName = "new_item", menuName = "bag/new_item")]
public class item : ScriptableObject
{
    public string tag;
    public string item_name;
    public Sprite item_image;
    public int price;
    public int held;
    [TextArea]
    public string iteminfo;
    public GameObject prefab;
    public int water;
}
