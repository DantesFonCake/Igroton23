using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(DirectionalMovementController))]
public class DirectionalSpriteController : MonoBehaviour
{
    private DirectionalMovementController movementController;
    //TODO: need to render sprites not color
    private SpriteRenderer sprite;
    [Header("Sprites Selection")] 
    public Color upColor;
    public Color downColor;
    public Color leftColor;
    public Color rightColor;

    private void Awake()
    {
        movementController = GetComponent<DirectionalMovementController>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        sprite.color = movementController.LastDirection switch
        {
            Direction.Up => upColor,
            Direction.Down => downColor,
            Direction.Left => leftColor,
            Direction.Right => rightColor,
            _ => throw new ArgumentOutOfRangeException(nameof(movementController.LastDirection),
                movementController.LastDirection, null)
        };
    }
}
