using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "garden", menuName = "garden/garden")]
public class garden : ScriptableObject
{
    public List<crop> itemlist=new List<crop>();
}
