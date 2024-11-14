using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARFilteredPlane : MonoBehaviour
{

    //8
    [SerializeField] private Vector2 dimensionsForBigPlane;

    //9
    public event Action OnVerticalPlaneFound;
    public event Action OnHorizontalPlaneFound;
    public event Action OnBigPlaneFound;

    //1
    private ARPlaneManager _arPlaneManager;

    //2
    private List<ARPlane> arPlanes;


    //3,4
    public void OnEnable()
    {
        arPlanes = new List<ARPlane>();
        _arPlaneManager = FindObjectOfType<ARPlaneManager>();
        _arPlaneManager.planesChanged += OnPlanesChanged;
    }

    public void OnDisable()
    {
        _arPlaneManager.planesChanged -= OnPlanesChanged;
    }


    //5
    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {

        //6
        if(args.added != null && args.added.Count > 0)
        {
            arPlanes.AddRange(args.added);
        }

        //7
        foreach(ARPlane plane in arPlanes.Where(plane => plane.extents.x * plane.extents.y >= 0.1f))
        {
            if (plane.alignment.IsVertical())
            {
                //Vertical을 찾을경우
                //10
                OnVerticalPlaneFound.Invoke();
            }
            else
            {
                //Horizontal을 찾을경우
                //11
                OnHorizontalPlaneFound.Invoke();
            }

            //9
            if(plane.extents.x * plane.extents.y >= dimensionsForBigPlane.x * dimensionsForBigPlane.y)
            {
                //Big Plane 찾음
                //12
                OnBigPlaneFound.Invoke();
            }
        }
    }
}
