using UnityEngine;

[ExecuteInEditMode]
public class LandmarkCamera : MonoBehaviour
{
  public float camDist;
  public float lerpSpeed;
  public Vector3 camOffset;
  public Transform player;
  public Transform cam;
  public Transform landmark;
  public float landmarkInterestDist = 10f;
  public float elevationAngle = 15f;

  private void Update()
  {
    Vector3 playerToLandmarkDir = (landmark.position - player.position).normalized;
    Vector3 cameraDir = (playerToLandmarkDir + player.forward).normalized;

    Quaternion baseRotation = Quaternion.LookRotation(cameraDir, Vector3.up);
    
    Quaternion elevationRotation = Quaternion.AngleAxis(elevationAngle, baseRotation * Vector3.up);
    Quaternion targetRot = baseRotation * elevationRotation;
    
    Vector3 cameraPos = player.position - cam.forward * camDist;
    cameraPos += camOffset;
    
    cam.position = Vector3.Lerp(cam.position, cameraPos, lerpSpeed * Time.deltaTime);
    cam.rotation = Quaternion.Slerp(cam.rotation, targetRot, lerpSpeed * Time.deltaTime);
  }
}
