using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    float rotationSpeed = 500f;

    Quaternion targetRotation;

    CameraController cameraController;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        cameraController =  Camera.main.GetComponent<CameraController>();
     animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
    float h = Input.GetAxis("Horizontal"); 
    float v = Input.GetAxis("Vertical");        

    var moveInput = (new Vector3(h,0,v)).normalized;

    float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

    var moveDir = cameraController.PlannerRotation * moveInput;

    if(moveAmount > 0) {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        targetRotation= Quaternion.LookRotation(moveDir);
    }
    transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);

    animator.SetFloat("moveAmount",moveAmount,0.2f,Time.deltaTime);
    }
}
