using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.XR.ARFoundation;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARAnchorManager))]
public class AnchorCreator : MonoBehaviour
{
    private ARRaycastManager _raycastManager;
    private ARAnchorManager _anchorManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Pose hitPose;

    [SerializeField] private GameObject anchorPrefab;

    private void Start()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
        _anchorManager = GetComponent<ARAnchorManager>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                if(_raycastManager.Raycast(touch.position, hits))
                {
                    HandleRaycastHits(hits);
                }
            }
        }
    }

    private void HandleRaycastHits(List<ARRaycastHit> hits)
    {
        if (hits[0].trackable is ARPlane)
        {
            hitPose = hits[0].pose;
            CreateAnchor();
        }
    }

    private void CreateAnchor()
    {
        var anchorObject = Instantiate(anchorPrefab, hitPose.position, hitPose.rotation);
        anchorObject.AddComponent<ARAnchor>();
    }
}
