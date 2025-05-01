using System;
using UnityEngine;

public class CrossProduct : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Transform objA;
    [SerializeField] private Transform objB;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        var newPos = Vector3.Cross(Vector3.up, objA.forward).normalized;
        
        objB.position = objA.position + (newPos + offset);
    }
}
