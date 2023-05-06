using UnityEngine;

[RequireComponent(typeof(DirectionalMovementController))]
public class EnemyController : MonoBehaviour
{
    private DirectionalMovementController selfController;
    private Transform playerTransform;

    private void Awake()
    {
        selfController = GetComponent<DirectionalMovementController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        var position = (Vector2)transform.position;
        var nextPosition =
            Vector2.MoveTowards(position, playerTransform.position, Time.deltaTime * selfController.speed);
        var direction = nextPosition - position;
        direction.Normalize();

        selfController.ApplyDirectionalVelocity(direction);
    }
}