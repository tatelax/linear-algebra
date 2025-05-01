using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
  [Header("Config")]
  [SerializeField] private float dist;
  [SerializeField] private float speed;
  [SerializeField] private Transform player;
  [SerializeField] private Transform cam;
  [SerializeField] private Vector3 offset;

  private void Update()
  {
    var playerPos = player.position;

    var behindPos = player.forward * dist;

    var newCamPos = (playerPos - behindPos)  + offset;

    var currCamPos = cam.position;

    var currCamRot = cam.rotation;

    var currPlayerRot = player.rotation;

    var targetRot = Quaternion.LookRotation(player.forward, Vector3.up);
    
    cam.position = Vector3.Lerp(currCamPos, newCamPos, speed * Time.deltaTime);
    cam.rotation = Quaternion.Slerp(currCamRot, targetRot, speed * Time.deltaTime);
  }
}
