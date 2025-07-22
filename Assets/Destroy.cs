using System;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        Destroy(other.gameObject);    
    }
}