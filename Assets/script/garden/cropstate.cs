using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
[CreateAssetMenu(fileName = "crop", menuName = "game/crop")]

public class cropstate : ScriptableObject
{
    public List<int> crop_type = new List<int>();
    public List<int> crop_phase = new List<int>();
    public List<int> crop_watered = new List<int>();
    public List<int> stop_hour = new List<int>();
    public List<int> stop_day = new List<int>();


}






