using UnityEngine;

public class MoveObject : MonoBehaviour
{
        [Header("Config")]
        [SerializeField] private float speed = 10.0f;
        [SerializeField] private Transform obj;
        [SerializeField] private Transform target;

        private void Update()
        {
                var objCurrPos = obj.position;
                var targetCurrPos = target.position;

                var dir = targetCurrPos - objCurrPos;

                var dirNormalized = dir.normalized;


                obj.transform.position += dirNormalized * (speed * Time.deltaTime);
        }
}