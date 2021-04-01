using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRigController : MonoBehaviour
{
    public SelectNPC selectNPC;

    [Header("Object References")]
    //[Tooltip("Exponential boost factor on translation, controllable by mouse wheel.")]
    public CinemachineFreeLook freeCam;

    [Header("Target Tracking")]
    public Transform targetTransform;
    public float followSpeed;
    public float targetYOffset;
    public bool isFollowing;

    [Header("Movement Settings")]
    public Vector3 newPosition;
    public float movementSpeedModifier;

    [Header("Mouse Movement Settings")]
    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public float mouseMovementSpeed;

    [Header("Keyboard Movement Settings")]
    public float normalSpeed;
    public float fastSpeed;
    public float currentMovementSpeed;
    public float movementTime;

    [Header("Rotation Settings")]
    public Quaternion newRotation;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;
    public float rotationAmount;

    private void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        mouseMovementSpeed = Camera.main.transform.position.y;
        if (mouseMovementSpeed < 20)
            mouseMovementSpeed = 20;
        if (mouseMovementSpeed > 100)
            mouseMovementSpeed = 100;

        LerpTowards();

        if (isFollowing && targetTransform)
        {
            newPosition = new Vector3(targetTransform.position.x, targetTransform.position.y + targetYOffset, targetTransform.position.z);

            if (Input.GetMouseButtonDown(1) ||
            Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if(isFollowing)
                    ClearFollowTarget();
                return;
            }
        }
        HandleKeyboardMovement();
        HandleMouseInput();
        HandleMouseRotation();
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            newPosition += transform.forward * mouseY * mouseMovementSpeed * Time.deltaTime;
            newPosition += transform.right * mouseX * mouseMovementSpeed * Time.deltaTime;
        }
    }

    void HandleMouseRotation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotateStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            rotateCurrentPosition = Input.mousePosition;
            Vector3 difference = rotateStartPosition - rotateCurrentPosition;
            rotateStartPosition = rotateCurrentPosition;
            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }

        float normal = Mathf.InverseLerp(0, 360, transform.eulerAngles.y);
        float converted = Mathf.Lerp(-180, 180, normal);
        freeCam.m_XAxis.Value = converted;
    }

    void HandleKeyboardMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMovementSpeed = fastSpeed;
        }
        else
        {
            currentMovementSpeed = normalSpeed;
        }


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * -currentMovementSpeed);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * currentMovementSpeed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * currentMovementSpeed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * -currentMovementSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }

        if (Input.GetKey(KeyCode.Z))
        {

        }

        if (Input.GetKey(KeyCode.X))
        {

        }
    }

    private void LerpTowards()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * followSpeed);
        }

        else if (!isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
    }

    public void SetFollowTarget(Transform target)
    {
        if (!targetTransform)
        {
            targetTransform = this.transform;
        }
        isFollowing = true;
        targetTransform = target;

    }

    void ClearFollowTarget()
    {
        isFollowing = false;
        targetTransform = null;
        selectNPC.ClearTarget();
    }

}
