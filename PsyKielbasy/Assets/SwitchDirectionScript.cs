using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDirectionScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<DogMove>().radialSpeed *= -1;
        }
    }
}
