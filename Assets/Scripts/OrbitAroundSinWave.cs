using UnityEngine;

public class OrbitAroundSinWave : MonoBehaviour
{
  public Transform camera;
  public Transform target;
  public float radius;
  public float speed;
  public float height;
  public float angleOffset = 15f;

  private float currentAngle;
  
  private void Update()
  {
    // Calculate the current angle in radians based on time and speed
    currentAngle = (currentAngle + Time.deltaTime * speed) % 360;

    // Compute x and z coordinates for a circle
    float x = Mathf.Cos(currentAngle) * radius;
    float z = Mathf.Sin(currentAngle) * radius;
    
    // Set the new position relative to the center object's position
    camera.position = target.position - new Vector3(x, height, z);

    var lookDir = target.position - camera.position;
    var angleQuaternion = Quaternion.AngleAxis(angleOffset, camera.right);
    
    camera.rotation = Quaternion.LookRotation(angleQuaternion * lookDir);
  }
}
