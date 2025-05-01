using UnityEngine;

public class RotationFundamentals : MonoBehaviour
{
    public float angle = 45f;
    public Transform[] objs;
    public float speed;
    public AnimationCurve ease = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private float timeElapsed = 0;
    private bool running;
    
    private void Update()
    {
        var rotWithOffset = Quaternion.LookRotation(objs[1].position) * Quaternion.AngleAxis(angle, Vector3.right);

        //objs[0].rotation = Quaternion.LookRotation(objs[1].position);
        //objs[0].rotation = Quaternion.AngleAxis(angle, Vector3.right);
        //objs[0].rotation = rotWithOffset;
        //objs[0].rotation = Quaternion.Inverse(rotWithOffset);
        //objs[0].rotation = Quaternion.RotateTowards(objs[0].rotation, rotWithOffset, speed * Time.deltaTime);
        if (timeElapsed < speed)
        {
            float linearT = timeElapsed / speed;
            float easedT = ease.Evaluate(linearT);

            objs[0].rotation = Quaternion.Slerp(objs[0].rotation, rotWithOffset, easedT);

            timeElapsed += Time.deltaTime;
        }
    }
}