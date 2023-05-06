using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [Header("Tracker Settings")]
    public Camera followingCamera;
    public float followSpeed = 2;
    public float maxFollowLag = 10;

    private void Update()
    {
        var selfPosition = transform.position;
        var cameraTransform = followingCamera.transform;
        var cameraPosition = cameraTransform.position;
        var requiredCameraPosition = new Vector3(selfPosition.x, selfPosition.y, cameraPosition.z);

        var reverseDirection = cameraPosition - requiredCameraPosition;

        var sqrDistanceToLagCircle = reverseDirection.sqrMagnitude - maxFollowLag * maxFollowLag;
        if (sqrDistanceToLagCircle > 0)
        {
            cameraTransform.position = cameraPosition + Vector3.ClampMagnitude(reverseDirection, maxFollowLag) - reverseDirection;
            return;
        }

        cameraTransform.position = Vector3.MoveTowards(cameraPosition, requiredCameraPosition, followSpeed * Time.deltaTime);
    }
}
