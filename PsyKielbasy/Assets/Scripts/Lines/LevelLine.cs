using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLine : Line
{
    public override void AddPoint(Vector2 point)
    {
        base.AddPoint(point);
        base.BakeLine();
    }
}
