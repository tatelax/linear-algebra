using UnityEngine;

public class VectorFundamentals : MonoBehaviour
{
  public float speed;
  public Transform[] obj;
  public Vector3 posA;
  public Vector3 posB;
  public Vector3 posC;

  public void Update()
  {
    obj[1].position = posA;

    obj[2].position = posB;

    posC = posA - posB;

    obj[3].position = posC;

    obj[0].position += posC.normalized * speed;
  }
}