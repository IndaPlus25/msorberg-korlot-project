using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float dampTime = 0.15f;
    public float lookAhead = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = target.transform.position;
        Vector3 delta = targetPos - currentPos;
        Vector2 velocity = Vector2.zero;
        Vector3 movement = Vector2.SmoothDamp(currentPos, targetPos, ref velocity, dampTime);
        movement += delta * lookAhead;
        movement.z = -10; // To zoom the camera out
        transform.position = movement;
    }
}
