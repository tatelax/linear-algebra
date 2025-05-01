using System;
using System.Collections;
using UnityEngine;

public class LerpWithCurve : MonoBehaviour
{
  public Transform a, b;
  public AnimationCurve curve;
  public float animTime = 2f;
  
  private void Start()
  {
    StartCoroutine(DoLerp());
  }

  private IEnumerator DoLerp() 
  {
    float elapsedTime = 0;
    
    while (elapsedTime < animTime)
    {
      var t = elapsedTime / animTime;
      t = curve.Evaluate(t);
      
      a.position = Vector3.Lerp(a.position, b.position, t);
      
      elapsedTime += Time.deltaTime;
          
      yield return null;
    }
  }
}
