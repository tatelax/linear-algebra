using UnityEngine;

public class MessingAround : MonoBehaviour
{
  [SerializeField] private Transform a;
  [SerializeField] private Transform b;
  
  private void Update()
  {
    Vector3 newPos = Vector3.Cross(Vector3.up, a.forward);

    b.position = a.position + newPos;
  }
}

