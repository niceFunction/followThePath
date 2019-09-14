
using UnityEngine;

public class scr_CameraFollow : MonoBehaviour
{
    private Transform target;
    [Range(0.0f, 1f)]
    public float smoothSpeed = 0.5f;
    // 0.125
    public Vector3 offset;

    private GameObject playerPrefab;

    private void Start()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void LateUpdate()
    {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
    }
}
