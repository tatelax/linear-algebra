using UnityEngine;

public class DistanceBetween : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Transform obj;
    [SerializeField] private Transform target;

    private void Update()
    {
        Debug.Log($"Distance: {target.transform.position - obj.transform.position}");
    }
}