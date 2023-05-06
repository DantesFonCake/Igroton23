using UnityEngine;

[RequireComponent(typeof(DirectionController))]
[RequireComponent(typeof(Rigidbody2D))]
public class DirectionalMovementController : MonoBehaviour
{
    [Header("Movement Settings")] public float accelerationFactor = 1;
    public float drag = 1;
    public float maxSpeed = 10;

    private Rigidbody2D boatBody;
    private DirectionController directionController;
    private Vector2 acceleration;

    private void Awake()
    {
        boatBody = GetComponent<Rigidbody2D>();
        directionController = GetComponent<DirectionController>();
    }

    private void FixedUpdate()
    {
        boatBody.AddForce(acceleration * accelerationFactor, ForceMode2D.Force);
        boatBody.velocity = Vector2.ClampMagnitude(boatBody.velocity, maxSpeed);
        boatBody.drag = acceleration.SqrMagnitude() == 0 ? drag : 0;
        boatBody.MoveRotation(directionController.LastDirection.GetRotationAngle());
    }

    public void ApplyDirectionalAcceleration(float horizontalMagnitude, float verticalMagnitude)
    {
        var newAcceleration = new Vector2(horizontalMagnitude, verticalMagnitude);

        directionController.ApplyDirectionChange(horizontalMagnitude, verticalMagnitude);

        acceleration = newAcceleration;
    }
}