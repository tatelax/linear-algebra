using System;
using UnityEngine;

public class LeftOrRightSide : MonoBehaviour
{
  public Transform a;
  public Transform b;
  public Transform c;

  private void Update()
  {
    Debug.Log(IsPointOnLeftSide(a.position, b.position, c.position));
  }
  
  bool IsPointOnLeftSide(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
  {
    // Create line direction vector
    Vector3 lineDirection = lineEnd - lineStart;
    
    // Vector from line start to the point
    Vector3 lineToPoint = point - lineStart;
    
    // Cross product determines left/right (in 3D space)
    Vector3 cross = Vector3.Cross(lineDirection, lineToPoint);
    
    Debug.Log(cross);
    
    // Dot product helps check if point is alongside the line segment
    float dot = Vector3.Dot(lineToPoint, lineDirection);
    float lineLengthSquared = lineDirection.sqrMagnitude;
    
    // Check if point is alongside (not past endpoints)
    bool isAlongside = (dot >= 0 && dot <= lineLengthSquared);
    
    // In 2D (assuming Y is up), we check the Z component of cross product
    // Positive Z means point is on the left side
    return isAlongside && cross.z > 0;
  }
}
