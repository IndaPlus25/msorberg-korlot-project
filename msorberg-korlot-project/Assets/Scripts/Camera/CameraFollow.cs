using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float dampTime = 0.15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = target.transform.position;
        Vector3 velocity = Vector2.zero;
        Vector3 movement = Vector3.SmoothDamp(currentPos, targetPos, ref velocity, dampTime);
        movement.z = -10; // To zoom the camera out
        transform.position = movement;
    }
}
