using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogMove : MonoBehaviour
{
    [SerializeField] private float radialSpeed;
    [SerializeField] private Rigidbody rigidbody;
    bool Grounded;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
    void Start()
    {
        SceneManager.sceneLoaded += TPToStartingPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Grounded)
        {
            rigidbody.AddTorque(new Vector3( 0, 0, -radialSpeed));
        }
        
    }

    private void TPToStartingPoint(Scene scene, LoadSceneMode mode)
    {
        var point = GameObject.Find("StartPoint");
        if ( point != null )
        {
            this.transform.position = point.transform.position;
            //For Debug Porpuses
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
    public void OnDestroy()
    {
        SceneManager.sceneLoaded -= TPToStartingPoint;

    }
}
