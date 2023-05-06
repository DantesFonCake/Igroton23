using UnityEngine;

[RequireComponent(typeof(DirectionController))]
[RequireComponent(typeof(Rigidbody2D))]
public class DirectionalMovementController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float drag = 1;
    public float speed = 10;

    private Rigidbody2D boatBody;
    private DirectionController directionController;
    private Vector2 velocityRequest;

    private void Awake()
    {
        boatBody = GetComponent<Rigidbody2D>();
        directionController = GetComponent<DirectionController>();
    }

    private void FixedUpdate()
    {
        var nextVelocity = Vector2.ClampMagnitude(velocityRequest, speed);
        boatBody.velocity = nextVelocity;
        boatBody.drag = nextVelocity.SqrMagnitude() == 0 ? drag : 0;
        boatBody.MoveRotation(directionController.GetRotationAngle());
    }

    public void ApplyDirectionalVelocity(Vector2 velocity)
    {
        velocityRequest = velocity * speed;
        
        directionController.ApplyDirectionChange(velocity.x, velocity.y);
    }
}