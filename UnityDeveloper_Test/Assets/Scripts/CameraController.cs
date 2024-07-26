using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
     Transform followTarget;

    [SerializeField] 
    float distance = 5;

    [SerializeField] 
    float rotationSpeed = 5f;

    [SerializeField] 
    float minVerticalAngle = -10;

    [SerializeField] 
    float maxVerticalAngle = 45;

    [SerializeField] 
    Vector2 framingOffset;

    [SerializeField] 
    bool invertX;
    [SerializeField] 
    bool invertY;

    float invertXVal;
    float invertYVal;

    float rotationX;
    float rotationY;

    void Start() {
     Cursor.visible = false;
     Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        invertXVal = (invertX)? -1 : 1;
        invertYVal = (invertY)? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * invertYVal* rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle,maxVerticalAngle);
        rotationY += Input.GetAxis("Mouse X") * invertXVal * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX,rotationY,0);

        // Camera Focus Region Area 
        var focusPosition = followTarget.position + new Vector3(framingOffset.x,framingOffset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0,0,distance);
        transform.rotation = targetRotation;
        
    }

    public Quaternion PlannerRotation => Quaternion.Euler(0,rotationY,0);
}
