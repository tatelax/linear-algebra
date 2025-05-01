using UnityEngine;

public class VectorMultiplication : MonoBehaviour
{
  public Vector3 pos;
  public Vector3 offset = Vector3.one;
  public Transform target;
  
  private void Update()
  {
    var newPos = new Vector3(pos.x * offset.x, pos.y * offset.y, pos.z * offset.z);

    target.rotation = Quaternion.Euler(newPos);
  }
}
