using System;
using UnityEngine;

public class ScaleSineWave : MonoBehaviour
{
  public Transform target;
  public Vector2 scaleOffset;
  public float speed;
  
  private void Update()
  {
    var y = Math.Sin(Time.time * speed) * scaleOffset.x;

    Vector3 newScale = new Vector3(target.localScale.x, target.localScale.y + (float)y, target.localScale.z);
    target.localScale = newScale;
  }
}
