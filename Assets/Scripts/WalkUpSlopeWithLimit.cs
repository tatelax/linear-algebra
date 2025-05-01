using UnityEngine;

public class WalkUpSlopeWithLimit : MonoBehaviour
{
  public Transform player;
  public float speed;
  public float maxAngle = 30f;
  
  private void Update()
  {
    float vertical = Input.GetAxis("Vertical");

    player.position += player.forward * (speed * Time.deltaTime * vertical);

    if (Physics.Raycast(player.position, Vector3.down, out RaycastHit hitInfo))
    {
      var dot = Vector3.Dot(hitInfo.normal, Vector3.up);

      print(dot);

      //player.rotation = Quaternion.LookRotation(cross, hitInfo.normal);
    }
  }
}
