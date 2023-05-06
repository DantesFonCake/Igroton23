using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DirectionalMovementController : MonoBehaviour
{
    [Header("Movement Settings")] public float AccelerationFactor = 1;
    public float Drag = 1;

    private Rigidbody2D boatBody;
    private Vector2 acceleration;
    public Direction LastDirection { get; private set; }

    private void Awake()
    {
        boatBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        boatBody.AddForce(acceleration * AccelerationFactor, ForceMode2D.Force);
        boatBody.drag = acceleration.SqrMagnitude() == 0 ? Drag : 0;
    }

    public void ApplyDirectionalAcceleration(float horizontalMagnitude, float verticalMagnitude)
    {
        acceleration = new Vector2(horizontalMagnitude, verticalMagnitude);

        if (horizontalMagnitude == 0 && verticalMagnitude == 0)
            return;

        if (horizontalMagnitude > 0)
            LastDirection = Direction.Right;
        else if (verticalMagnitude > 0)
            LastDirection = Direction.Up;
        else if (verticalMagnitude < 0)
            LastDirection = Direction.Down;
        else
            LastDirection = Direction.Left;
    }
}