using System;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
        [Header("Config")]
        [SerializeField] private float speed = 10f;
        [SerializeField] private Transform obj;
        [SerializeField] private Transform target;

        private void Update()
        {
                var currRot = obj.rotation.eulerAngles;

                currRot.y += speed * Time.deltaTime;
                
                obj.rotation = Quaternion.Euler(currRot);
        }
}