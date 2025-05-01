using UnityEngine;

public class RotateTowards : MonoBehaviour
{
  [Header("Config")]
  [SerializeField] private float rotateSpeed = 10.0f;
  [SerializeField] private Transform obj;
  [SerializeField] private Transform target;
  
  private void Update()
  {
    var targetRot = Quaternion.LookRotation(target.position - obj.position);

    obj.rotation = Quaternion.Slerp(obj.rotation, targetRot, rotateSpeed * Time.deltaTime);
  }

  private void OnValidate()
  {
    Debug.Assert(obj != null);
    Debug.Assert(target != null);
  }
}
