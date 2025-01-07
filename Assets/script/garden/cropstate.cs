using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "crop", menuName = "game/crop")]

public class cropstate : ScriptableObject
{
    public List<string> crop_type = new List<string>();
    public List<int> crop_time = new List<int>();

}





