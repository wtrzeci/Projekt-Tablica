using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogMove : MonoBehaviour
{
    private float StartSpeed;
    [SerializeField] public float radialSpeed;
    [SerializeField] private Rigidbody _rigidbody;
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
        Grounded = false;
        StartSpeed = radialSpeed;
        SceneManager.sceneLoaded += TPToStartingPoint;
        GameManager.switchDirection += Reverse;
        GameManager.Restart += _TpToStartingPoint;
    }
    private void Reverse()
    {
        radialSpeed *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Grounded)
        {
            _rigidbody.AddTorque(new Vector3( 0, 0, -radialSpeed));
        }
        
    }

    private void TPToStartingPoint(Scene scene, LoadSceneMode mode)
    {
        var point = GameObject.Find("StartPoint");
        if ( point != null )
        {
            this.transform.position = point.transform.position;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
    public void OnDestroy()
    {
        SceneManager.sceneLoaded -= TPToStartingPoint;
        GameManager.switchDirection -= Reverse;
        GameManager.Restart -= _TpToStartingPoint;
    }
    private void _TpToStartingPoint()
    {
        Grounded = false;
        radialSpeed = StartSpeed;
        var point = GameObject.Find("StartPoint");
        if (point != null)
        {
            this.transform.position = point.transform.position;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.Sleep();
    }
}
