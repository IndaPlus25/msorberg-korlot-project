using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Rigidbody2D rb;
    private Vector2 beforeTargetPos;
    public float dampTime = 0.15f;
    private Vector2 velocity = Vector2.zero;

    private ICameraLook IPeeking;
    public Vector2 peekVector;
    public float peekAheadDistance = 0.5f;
    public float lookAheadDistance = 2;
    private Vector2 targetLookAhead;
    public float lookAheadVelocitySmoothing = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beforeTargetPos = target.transform.position;
        IPeeking = target.GetComponentInParent<ICameraLook>();
        rb = target.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = target.transform.position;

        Vector2 targetDelta = rb.
        peekVector = Vector2.zero;
        if (IPeeking != null)
        {
            peekVector = IPeeking.GetLookDirection();
        }
        beforeTargetPos = targetPos;
        targetLookAhead = Vector3.Lerp(targetLookAhead, targetDelta+peekVector, lookAheadVelocitySmoothing);
        targetPos += targetLookAhead * lookAheadDistance;

        Vector3 dampedMovement = Vector2.SmoothDamp(currentPos, targetPos, ref velocity, dampTime);
        dampedMovement.z = -10; // To zoom the camera out
        transform.position = dampedMovement;
    }
}
