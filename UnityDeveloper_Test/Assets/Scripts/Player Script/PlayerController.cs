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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    float invertAxisDirection = -1;
    float horizontalAxis = Input.GetAxis("Horizontal");        
    float verticalAxis = Input.GetAxis("Vertical");        
    float h = horizontalAxis * invertAxisDirection;
    float v = verticalAxis * invertAxisDirection;

    var moveInput = (new Vector3(h,0,v)).normalized;

    float moveAmount = Mathf.Abs(h) + Mathf.Abs(v);

    if(moveAmount > 0) {
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        targetRotation= Quaternion.LookRotation(moveInput);
    }
    transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);
    }
}