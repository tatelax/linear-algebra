using UnityEngine;

public class LinearTransformation : MonoBehaviour
{
  public float speed = 0.2f;
  public Transform player;
  public Transform target;

  public Vector3 playerStartPos;
  
  public Vector2 i;
  public Vector2 j;
  
  private void Update()
  {
    var currPos = playerStartPos;
    var newPos = new Vector3(currPos.x * i.x + currPos.z * j.x, 0, currPos.x * i.y + currPos.z * j.y);

    player.position = Vector3.Lerp(player.position, newPos, speed * Time.deltaTime);
    
    Debug.DrawRay(Vector3.zero, new Vector3(i.x, 0, i.y), Color.green);
    Debug.DrawRay(Vector3.zero, new Vector3(j.x, 0, j.y), Color.red);
    Debug.DrawRay(Vector3.zero, newPos, Color.cyan);
    Debug.DrawRay(Vector3.zero, playerStartPos, Color.magenta);
  }
}
