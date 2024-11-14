using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilteredPlaneCanvas : MonoBehaviour
{
    //1,2
    [SerializeField] private Toggle verticalPlaneToggle;
    [SerializeField] private Toggle horizontalPlaneToggle;
    [SerializeField] private Toggle bigPlaneToggle;
    [SerializeField] private Button startButton;

    private ARFilteredPlane arFilteredPlanes;

    //5
    public bool VerticalPlaneToggle
    {
        get => verticalPlaneToggle.isOn;
        set
        {
            verticalPlaneToggle.isOn = value;
            CheckIfAllAreTrue();
        }
    }

    public bool HorizontalPlaneToggle
    {
        get => verticalPlaneToggle.isOn;
        set
        {
            horizontalPlaneToggle.isOn = value;
            CheckIfAllAreTrue();
        }
    }

    public bool BigPlaneToggle
    {
        get => verticalPlaneToggle.isOn;
        set
        {
            bigPlaneToggle.isOn = value;
            CheckIfAllAreTrue();
        }
    }

    //3,4
    private void OnEnable()
    {
        arFilteredPlanes = FindObjectOfType<ARFilteredPlane>();

        arFilteredPlanes.OnVerticalPlaneFound += () => VerticalPlaneToggle = true;
        arFilteredPlanes.OnHorizontalPlaneFound += () => HorizontalPlaneToggle = true;
        arFilteredPlanes.OnBigPlaneFound += () => BigPlaneToggle = true;
    }

    private void OnDisable()
    {
        arFilteredPlanes.OnVerticalPlaneFound -= () => VerticalPlaneToggle = true;
        arFilteredPlanes.OnHorizontalPlaneFound -= () => HorizontalPlaneToggle = true;
        arFilteredPlanes.OnBigPlaneFound -= () => BigPlaneToggle = true;
    }

    //6
    private void CheckIfAllAreTrue()
    {
        if (VerticalPlaneToggle)
        {
            startButton.interactable = true; 
        }
    }
}
