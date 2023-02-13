using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderScript : MonoBehaviour
{
    public static event Action GameLost;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameLost?.Invoke();
        }
    }
}
