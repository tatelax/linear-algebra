using UnityEngine;

public class RotateAround : MonoBehaviour
{
  [Header("Config")]
  [SerializeField] private float degreesPerSecond = 10.0f;
  [SerializeField] private Transform obj;
  [SerializeField] private Transform target;
  
  private void Update()
  {
    var angle = degreesPerSecond * Time.deltaTime;
    
    obj.RotateAround(target.position, Vector3.up, angle);
  }
}
