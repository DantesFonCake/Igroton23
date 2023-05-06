using System;
using UnityEngine;

[RequireComponent(typeof(DirectionController))]
public class DirectionalSpriteController : MonoBehaviour
{
    private DirectionController directionController;
    //TODO: need to render sprites not color
    private SpriteRenderer sprite;
    
    [Header("Sprites Selection")] 
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private void Awake()
    {
        directionController = GetComponent<DirectionController>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        sprite.sprite = directionController.LastDirection switch
        {
            Direction.Up => upSprite,
            Direction.Down => downSprite,
            Direction.Left => leftSprite,
            Direction.Right => rightSprite,
            _ => throw new ArgumentOutOfRangeException(nameof(directionController.LastDirection),
                directionController.LastDirection, null)
        };
    }
}
