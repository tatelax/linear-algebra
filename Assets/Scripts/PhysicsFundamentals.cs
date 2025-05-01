using System;
using UnityEngine;

public class PhysicsFundamentals : MonoBehaviour
{
  public float rotateSpeed = 50f;
  public float moveSpeed = 5f;
  public Rigidbody rb;
  public ForceMode forceMode;
  
  public void Update()
  {
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    
    rb.transform.Rotate(Vector3.up, horizontalInput * (rotateSpeed * Time.deltaTime));
    
    
  }

  private void FixedUpdate()
  {
    float verticalInput = Input.GetAxis("Vertical");

    Vector3 forward = rb.transform.forward * verticalInput;

    rb.AddForce(forward * moveSpeed, forceMode);
  }
}
