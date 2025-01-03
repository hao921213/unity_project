using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "crop", menuName = "garden/crop")]
public class crop : ScriptableObject
{
    public Sprite grow1;
    public Sprite grow2;
    public Sprite grow3;
    public Sprite grow4;
    public item item;
    public int time;
    public int grow_time;
}
