using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognizeExample : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedManager;

    private void Awake()
    {
        _arTrackedManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        _arTrackedManager.trackedImagesChanged += OnImageChanged;
    }

    public  void OnDisable()
    {
        _arTrackedManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(var trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
        }
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
