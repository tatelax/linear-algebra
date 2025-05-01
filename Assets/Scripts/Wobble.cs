using System;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    public Transform target;
    public float angle;
    public float speed;
    public float lerpSpeed = 5f;
    
    private float currentAngle = 0f;
    
    private void Update()
    {
        currentAngle = (currentAngle + Time.deltaTime * speed) % 360;
        
        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.right);
        Quaternion rotation = Quaternion.AngleAxis(currentAngle, Vector3.up);
        Quaternion targetRotation = rotation * angleAxis;

        target.rotation = targetRotation;

        angle = Mathf.Lerp(angle, 0, lerpSpeed * Time.deltaTime);
        speed = Mathf.Lerp(speed, 5000f, lerpSpeed * Time.deltaTime);
    }
}
