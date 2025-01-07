using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "crop", menuName = "game/crop")]

public class cropstate : ScriptableObject
{
    public List<char> crop_type = new List<char>();
    public List<char> crop_time = new List<char>();
}





