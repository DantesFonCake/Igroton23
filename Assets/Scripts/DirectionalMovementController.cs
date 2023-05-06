using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DirectionalMovementController : MonoBehaviour
{
    [Header("Movement Settings")] public float accelerationFactor = 1;
    public float drag = 1;
    public float maxSpeed = 10;

    private Rigidbody2D boatBody;
    private Vector2 acceleration;

    public Direction LastDirection { get; private set; }

    private void Awake()
    {
        boatBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        boatBody.AddForce(acceleration * accelerationFactor, ForceMode2D.Force);
        boatBody.velocity = Vector2.ClampMagnitude(boatBody.velocity, maxSpeed);
        boatBody.drag = acceleration.SqrMagnitude() == 0 ? drag : 0;
        boatBody.MoveRotation(LastDirection.GetRotationAngle());
    }

    public void ApplyDirectionalAcceleration(float horizontalMagnitude, float verticalMagnitude)
    {
        var newAcceleration = new Vector2(horizontalMagnitude, verticalMagnitude);

        ApplyDirectionChange(horizontalMagnitude, verticalMagnitude);

        acceleration = newAcceleration;
    }

    private void ApplyDirectionChange(float horizontalMagnitude, float verticalMagnitude)
    {
        if (horizontalMagnitude == 0 && verticalMagnitude == 0) 
            return;
        
        var vDirection = verticalMagnitude > 0 ? Direction.Up : Direction.Down;
        var hDirection = horizontalMagnitude > 0 ? Direction.Right : Direction.Left;
        var hAbsMagnitude = Mathf.Abs(horizontalMagnitude);
        var vAbsMagnitude = Mathf.Abs(verticalMagnitude);
        if (!Mathf.Approximately(hAbsMagnitude, vAbsMagnitude))
        {
            LastDirection = hAbsMagnitude > vAbsMagnitude ? hDirection : vDirection;
            return;
        }

        if (Math.Sign(acceleration.x) != Math.Sign(horizontalMagnitude))
        {
            LastDirection = hDirection;
            return;
        }

        if (Math.Sign(acceleration.y) != Math.Sign(verticalMagnitude))
            LastDirection = vDirection;
    }
}