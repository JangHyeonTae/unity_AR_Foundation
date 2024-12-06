using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRig : MonoBehaviour
{
    public Transform playerHead;
    public CapsuleCollider bodyCollider;

    public float bodyHeightMin = 0.5f;
    public float bodyHeightMax = 1.7f;

    public Vector3 startPosition =  Vector3.zero;

    void Start()
    {
        gameObject.transform.position = new Vector3(1.4f, -0.6f, -0.15f);
    }
    void FixedUpdate()
    {
        bodyCollider.height = Mathf.Clamp(playerHead.localPosition.y, bodyHeightMin, bodyHeightMax);
        bodyCollider.center = new Vector3(playerHead.localPosition.x, bodyCollider.height / 2, playerHead.localPosition.z);
    }
}
