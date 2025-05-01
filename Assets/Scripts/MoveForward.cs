using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform obj;

    private void Update()
    {
        var forward = obj.transform.forward;

        var newPos = obj.transform.position;
        newPos += forward * (speed * Time.deltaTime);
        
        obj.transform.position = newPos;
    }
}
