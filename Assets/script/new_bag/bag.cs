using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_bag", menuName = "bag/new_bag")]
public class bag : ScriptableObject
{
    public List<item> itemlist=new List<item>();
}
