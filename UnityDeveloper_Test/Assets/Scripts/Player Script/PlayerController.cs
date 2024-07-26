using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    float rotationSpeed = 500f;

    [Header("Ground Check Settings")]
    [SerializeField]
    float groundCheckRadius = 0.2f;
    [SerializeField]
    Vector3 groundCheckOffset;
    [SerializeField]
    LayerMask groundLayer;

    bool isGrounded;

    float ySpeed;

    Quaternion targetRotation;

    CameraController cameraController;
    Animator animator;
    CharacterController characterController;
    // Start is called before the first frame update
    void Awake()
    {
        cameraController =  Camera.main.GetComponent<CameraController>();
     animator = GetComponent<Animator>();    
     characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
    float h = Input.GetAxis("Horizontal"); 
    float v = Input.GetAxis("Vertical");        

    var moveInput = (new Vector3(h,0,v)).normalized;

    float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

    var moveDir = cameraController.PlannerRotation * moveInput;

    GroundCheck();
    

    Debug.Log("IsGrounded = "+ isGrounded);
    if(isGrounded) {
        ySpeed = -0.5f;
    }else{
        ySpeed += Physics.gravity.y * Time.deltaTime;
    }
    var velocity = moveDir * moveSpeed;
    velocity.y = ySpeed; 
     characterController.Move( velocity * Time.deltaTime);

    if(moveAmount > 0) {
        targetRotation= Quaternion.LookRotation(moveDir);
    }
    transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);

    animator.SetFloat("moveAmount",moveAmount,0.2f,Time.deltaTime);
    }

    void GroundCheck(){
    isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset),groundCheckRadius,groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0,1,0,0.5f);
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset),groundCheckRadius);
    }
}
