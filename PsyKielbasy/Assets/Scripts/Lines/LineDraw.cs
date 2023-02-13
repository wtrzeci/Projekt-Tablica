using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    [SerializeField] private float LineLength;
    [SerializeField] protected Line ActiveLine = null;
    //speed up the ball
    [SerializeField] private GameObject SpeedLine;
    //normal chalk line used in levels
    [SerializeField] private GameObject NormalLine;
    //trampoline prefab used in build mode, trampolines can only be horizontal
    [SerializeField] private GameObject Trampoline;
    //Currently drawed line
    [SerializeField] protected GameObject CurrentLinePrefab;
    //flag used for building 
    [SerializeField] private bool IsBuilding;
    //Current structure being build
    private GameObject building;
    public static LineDraw Instance;
    private List<GameObject> Lines = new List<GameObject>();
    #region LineChangesButtons
    public void ChangeToSpeedLine()
    {
        CurrentLinePrefab = SpeedLine;
    }
    public void ChangeToNormalLine()
    {
        CurrentLinePrefab = NormalLine;
    }
    public void BuildTrampoline()
    {
        CurrentLinePrefab = Trampoline;

    }
    #endregion
    void Start()
    {
        IsBuilding = false;
        CurrentLinePrefab = NormalLine;
        Instance = this.gameObject.GetComponent<LineDraw>();
        Lines.Clear();
        GameManager.Restart += DestroyAllLines;
    }

    // Update is called once per frame
    void Update()
    {
        #region line Drawing
        if (!IsBuilding && CurrentLinePrefab!=null)
        { 
            if (Input.GetMouseButtonDown(0))
            {
                var Line = Instantiate(CurrentLinePrefab);
                ActiveLine = Line.GetComponent<Line>();
                Lines.Add(Line);
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
        #endregion
        #region Buildings

        /*if (building != null)
        {
            CurrentLinePrefab = null;
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            building.gameObject.GetComponent<LineRenderer>().SetPosition(0, pos +new Vector3(pos.x /10, pos.y/10, 10));
            building.gameObject.GetComponent<LineRenderer>().SetPosition(1, pos + new Vector3(pos.x/10 +1,pos.y/10,10));
            if(Input.GetMouseButtonDown(0))
            {
                building.GetComponent<TrampolineScript>().BakeMesh();
                building = null;
                IsBuilding = false;
            }
        }
*/
        #endregion
    }
    public void OnDestroy()
    {
        ActiveLine = null;
    }
    private void DestroyAllLines()
    {
        foreach(var line in Lines)
        {
            Destroy(line);
        }
    }
}
