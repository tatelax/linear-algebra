using UnityEngine;
using UnityEngine.Serialization;

public class CameraTransitions : MonoBehaviour
{
  public Transform cam;
  public Transform[] points;
  public int currPoint;
  public float distance = 10f;
  public float speed = 10f;
  public float height = 1f;

  private void Update()
  {
    var pos = GetPosition();
    var rot = GetRotation();
    
    cam.SetPositionAndRotation(pos, rot);
  }

  private Quaternion GetRotation()
  {
    var currTrans = points[currPoint];
    var unitVector = (currTrans.position - cam.position).normalized;
    var newQuaternion = Quaternion.LookRotation(unitVector);
    return Quaternion.Slerp(cam.rotation, newQuaternion, speed * Time.deltaTime);
  }

  private Vector3 GetPosition()
  {
    var currTrans = points[currPoint];
    var unitVector = currTrans.right;
    var newPos = currTrans.position + (unitVector * distance);
    newPos.y = height;
    return Vector3.Lerp(cam.position, newPos, speed * Time.deltaTime);
  }
}
