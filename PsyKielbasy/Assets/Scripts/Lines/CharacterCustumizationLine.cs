using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustumizationLine : Line
{
    public override void UpdatePosition(Vector2 point)
    {
        base.UpdatePosition(point);
        Debug.Log("Position Updated");
    }
    public override void AddPoint(Vector2 point)
    {
        base.AddPoint(point);
    }
}
