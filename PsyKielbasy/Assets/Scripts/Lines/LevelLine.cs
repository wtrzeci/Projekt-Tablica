using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLine : Line
{
    private void Start()
    {
        if (lineRenderer.positionCount != 0)
            base.BakeLine();
    }
    public override void AddPoint(Vector2 point)
    {
        base.AddPoint(point);
        base.BakeLine();
    }
}
