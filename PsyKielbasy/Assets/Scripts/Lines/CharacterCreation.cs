using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField] protected Line ActiveLine;
    [SerializeField] protected GameObject LinePrefab;
    [SerializeField] private GameObject DogObject;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var Line = Instantiate(LinePrefab);
            Line.transform.parent = DogObject.transform;
            ActiveLine = Line.GetComponent<CharacterCustumizationLine>();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ActiveLine = null;
        }
        if (ActiveLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ActiveLine.UpdatePosition(mousePos);
            Debug.Log("Drawing");
        }
    }
}
