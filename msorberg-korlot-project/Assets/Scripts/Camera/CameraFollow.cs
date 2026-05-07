using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector2 beforeTargetPos;
    public float dampTime = 0.15f;
    private Vector2 velocity = Vector2.zero;

    public float lookAheadDistance = 2;
    private Vector2 lookAheadVelocity;
    public float lookAheadVelocitySmoothing = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beforeTargetPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = target.transform.position;

        Vector2 targetDelta = (targetPos - beforeTargetPos) / Time.deltaTime;
        beforeTargetPos = targetPos;
        Vector2 targetLookAhead = Vector3.Lerp(lookAheadVelocity, targetDelta, lookAheadVelocitySmoothing);
        targetPos += targetLookAhead * lookAheadDistance;

        Vector3 dampedMovement = Vector2.SmoothDamp(currentPos, targetPos, ref velocity, dampTime);
        dampedMovement.z = -10; // To zoom the camera out
        transform.position = dampedMovement;
    }
}
