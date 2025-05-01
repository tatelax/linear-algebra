using UnityEngine;

public class SignRotation : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform sign;
    [SerializeField] private Transform signVisual;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistToFlip;

    private void Update()
    {
        var playerDistToSign = Vector3.Normalize(player.position - sign.position);
        
        float signDot = Vector3.Dot(sign.forward, playerDistToSign);

        int negative = signDot > 0 ? 1 : -1;

        Vector3 signTargetRot = new Vector3(0, 90 * negative, 0);

        signVisual.rotation = Quaternion.Euler(signTargetRot);
    }
}
