using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [Header("Tracker Settings")]
    public Camera followingCamera;

    private void Update()
    {
        var selfPosition = transform.position;
        var cameraTransform = followingCamera.transform;
        var newCameraPosition = new Vector3(selfPosition.x, selfPosition.y, cameraTransform.position.z);

        cameraTransform.position = newCameraPosition;
    }
}
