using System;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
  [Header("Config")]
  [SerializeField] private Transform objA;
  [SerializeField] private Transform objB;
  [SerializeField] private Vector3 offset;

  private void Update()
  {
    var objAForward = objA.forward;
    var dir = Vector3.Normalize(objB.position - objA.position);
    
    
    /*


objAForward
    *
    |       *  dir (direction of objA pointing towards obj B)
    |      /
    |     /
    |    /
    |   /
    |  /
    | /
    |/


     */
    
    Debug.Log(Vector3.Dot(objAForward, dir));
  }
}
