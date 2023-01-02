
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.100f;
    public Vector3 offset;  

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
