using System;
using UnityEngine;

[RequireComponent(typeof(DirectionController))]
public class DirectionalSpriteController : MonoBehaviour
{
    private DirectionController directionController;
    //TODO: need to render sprites not color
    private SpriteRenderer sprite;
    
    [Header("Sprites Selection")] 
    public Color upColor;
    public Color downColor;
    public Color leftColor;
    public Color rightColor;

    private void Awake()
    {
        directionController = GetComponent<DirectionController>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        sprite.color = directionController.LastDirection switch
        {
            Direction.Up => upColor,
            Direction.Down => downColor,
            Direction.Left => leftColor,
            Direction.Right => rightColor,
            _ => throw new ArgumentOutOfRangeException(nameof(directionController.LastDirection),
                directionController.LastDirection, null)
        };
    }
}
