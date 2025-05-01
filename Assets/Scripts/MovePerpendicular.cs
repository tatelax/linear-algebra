using System;
using UnityEngine;

public class MovePerpendicular : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float distance = 1f;
    [SerializeField] private Transform obj;
    [SerializeField] private Transform target;

    private void Update()
    {
        var perpendicular = Vector3.Cross(target.transform.right, Vector3.up).normalized;

        var newPos = obj.position + (perpendicular * (distance * Time.deltaTime));

        obj.transform.position = newPos;
    }
}
