using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector2 DownPosition;
    private Vector2 UpPosition;
    [SerializeField]
    private float minDistanceForSwipe = 20f;

    Rigidbody rb;
    Movement _movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _movement = FindObjectOfType<Movement>();

    }

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            
                if (touch.phase == TouchPhase.Began)
                {
                    DownPosition = touch.position;
                    UpPosition = touch.position;
                }

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    UpPosition = touch.position;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    UpPosition = touch.position;
                    CheckSwipe();

                }
            
        }
    }
    void CheckSwipe()
    {
        float deltaY = UpPosition.y - DownPosition.y;

        if (deltaY > minDistanceForSwipe)
        {
            if (deltaY > 0) // Up swipe
            {
                float jumpForce = deltaY;
                _movement.Jump(jumpForce);
                _movement.isGrounded = false;
            }
        }
    }
}
