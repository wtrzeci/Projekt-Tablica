using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public List<Vector2> points;
   [SerializeField] MeshCollider meshCollider;
    [SerializeField] protected float DistanceBetweenPoints = 0.1f;
    public virtual void UpdatePosition(Vector2 point)
    {
        if (points.Count == 0)
        {
            AddPoint(point);
            return;
        }
        if (Vector2.Distance(point, points.Last()) > DistanceBetweenPoints)
        {
            AddPoint(point);
        }
    }

    private void Start()
    {
        points = new List<Vector2>();
    }

    public virtual void AddPoint(Vector2 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }

    public void BakeLine()
    {
        Mesh mesh = new Mesh();
        lineRenderer.BakeMesh(mesh, true);
        meshCollider.sharedMesh = mesh;
        Debug.Log("Baking");
    }
    private void OnDestroy()
    {
        points.Clear();
    }


}
