using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectateCameraMovement : MonoBehaviour
{
    public CameraRigController _rigController;

    public float movementSpeed;
    public float rotationSpeed;

    private void LateUpdate()
    {
        if (!_rigController.isFollowing || !_rigController.targetTransform) return;
        var position = _rigController.targetTransform.position;
        Vector3 targetPos = new Vector3(position.x, position.y + 2.5f, position.z);
        Transform transform1;
        (transform1 = transform).position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * movementSpeed);
        //transform.position = targetPos;
        transform.rotation = Quaternion.Lerp(transform1.rotation, _rigController.targetTransform.rotation, Time.deltaTime * rotationSpeed);
    }
}
