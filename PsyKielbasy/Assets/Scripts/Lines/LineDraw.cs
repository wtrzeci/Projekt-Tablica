using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    [SerializeField] protected Line ActiveLine = null;
    [SerializeField] protected GameObject LinePrefab;
    // Start is called before the first frame update
    void Start()
    {  
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var Line =  Instantiate(LinePrefab);
            ActiveLine = Line.GetComponent<Line>();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ActiveLine = null;
        }
        if (ActiveLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ActiveLine.UpdatePosition(mousePos);
        }

        
    }
    public void OnDestroy()
    {
        ActiveLine = null;
    }
}
