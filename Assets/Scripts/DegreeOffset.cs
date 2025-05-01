using System;
using UnityEngine;

public class DegreeOffset : MonoBehaviour
{
    public Transform obj;
    public Transform target;
    public float offset;

    private void Update()
    {
        var rotation = Quaternion.AngleAxis(offset, Vector3.up);

        Vector3 rotatedDirection = rotation * (target.position - obj.position);
        
        obj.rotation = Quaternion.LookRotation(rotatedDirection);
        
    }
}
