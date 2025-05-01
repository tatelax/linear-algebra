using UnityEngine;

public class CalculateNormal : MonoBehaviour
{
  public Transform[] points;
  public Transform ball;
  public float distance = 2f;
  
  public void Update()
  {
    var unitVectorA = (points[0].position - points[1].position).normalized;
    var unitVectorB = (points[0].position - points[2].position).normalized;
    var cross = Vector3.Cross(unitVectorB, unitVectorA);

    var center = ((points[0].position + points[1].position) / 2 + points[2].position) / 2;

    ball.position = center + cross * distance;
  }
}
