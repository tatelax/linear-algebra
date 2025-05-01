using System;
using UnityEngine;
using Random = System.Random;

public class Pong : MonoBehaviour
{
  public float speed = 2f;
  public Transform ball;
  public Transform wallA;
  public Transform wallB;

  private Mesh mesh;
  private float ballRadius;
  
  private void Awake()
  {
    mesh = ball.gameObject.GetComponent<MeshFilter>().mesh;
    ballRadius = mesh.bounds.extents.x;
  }

  private void Start()
  {
    ball.rotation = Quaternion.LookRotation(wallA.position - ball.position);
  }

  private void Update()
  {
    var dir = ball.forward;
    
    ball.position += (dir * (speed * Time.deltaTime));

    var castPoint = ball.position + (ball.forward * ballRadius);
    
    Debug.DrawRay(castPoint, ball.forward, Color.red);
    
    if (Physics.Raycast(castPoint, ball.forward, out RaycastHit hitInfo))
    {
      if (hitInfo.distance > 0.01f)
      {
        return;
      }

      
      ball.rotation = Quaternion.LookRotation(hitInfo.normal , Vector3.up);
    }
  }
}
