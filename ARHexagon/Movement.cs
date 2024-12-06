using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Movement : MonoBehaviour
{
    XROrigin _xrOrigin;
    Rigidbody rb;

    [SerializeField] private float gravityValue = -9.8f;
    [SerializeField] private float jumpPower = 20f;
    public Vector3 gravityVector = new Vector3();


    public bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _xrOrigin = GetComponent<XROrigin>();
    }

    void Update()
    {
        if (_xrOrigin != null)
        {
            
            gravityVector = new Vector3(0, gravityValue, 0);
            Physics.gravity = gravityVector;
        }
    }

   private void OnCollisionEnter(Collision collision)
   {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

      
   }

    public void Jump(float jumpForce)
    {
        if (isGrounded)
        {
            if (jumpForce > 0.1)
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        
        
    }
}
