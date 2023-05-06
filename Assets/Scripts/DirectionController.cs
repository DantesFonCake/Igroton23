using System;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    private float lastHMagnitude;
    private float lastVMagnitude;
    
    public Direction LastDirection { get; private set; }
    
    public void ApplyDirectionChange(float horizontalMagnitude, float verticalMagnitude)
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

        if (Math.Sign(lastHMagnitude) != Math.Sign(horizontalMagnitude))
            LastDirection = hDirection;
        else if (Math.Sign(lastVMagnitude) != Math.Sign(verticalMagnitude))
            LastDirection = vDirection;

        lastHMagnitude = horizontalMagnitude;
        lastVMagnitude = verticalMagnitude;
    }
    
    public float GetRotationAngle() => LastDirection switch
    {
        Direction.Up => 0,
        Direction.Down => 180,
        Direction.Left => -90,
        Direction.Right => 90,
        _ => throw new ArgumentOutOfRangeException(nameof(LastDirection), LastDirection, null)
    };
}
