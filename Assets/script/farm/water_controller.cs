using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "water_controller", menuName = "farm/water")]
public class water_controller : ScriptableObject
{
    public List<float> waters=new List<float>();
}
