using System;
using UnityEngine;

public class ReflectionVector : MonoBehaviour
{
  public Transform ballA;
  public Transform wall;
  public Transform ballB;

  private void Update()
  {
    if (!Physics.Raycast(ballA.position, ballA.forward, out RaycastHit hitInfo)) return;
    
    // Get the incoming direction vector (from ballA to hit point)
    Vector3 incomingDirection = Vector3.Normalize(hitInfo.point - ballA.position);
    
    // Calculate the reflected direction
    Vector3 reflectedDirection = Vector3.Reflect(incomingDirection, hitInfo.normal);

    float bounceDistance = (hitInfo.point - ballA.position).magnitude;
    
    Quaternion lookDirection = Quaternion.LookRotation(reflectedDirection * -1);

    // Position ballB along the reflected direction at the desired distance
    ballB.position = hitInfo.point + reflectedDirection * bounceDistance;
    ballB.rotation = lookDirection;
  }
}
