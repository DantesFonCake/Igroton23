using UnityEngine;

[RequireComponent(typeof(DirectionalMovementController))]
public class PlayerInputHandler : MonoBehaviour
{
    private DirectionalMovementController playerController;

    private void Awake()
    {
        playerController = GetComponent<DirectionalMovementController>();
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        playerController.ApplyDirectionalVelocity(new Vector2(x, y));
    }
}
