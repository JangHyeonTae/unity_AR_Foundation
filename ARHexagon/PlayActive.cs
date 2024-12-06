using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;
using Unity.XR.CoreUtils;

public class PlayActive : MonoBehaviour
{
    public XROrigin _xrOrigin;
    public GameObject playerPrefab;
    public GameObject startButton;
    public GameObject text;

    void Start()
    {
        _xrOrigin.enabled = false;
        playerPrefab.SetActive(false);
        startButton.SetActive(true);
        text.GetComponent<Timer>().enabled = false;
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        playerPrefab.SetActive(true);
        _xrOrigin.enabled = true;
        startButton.SetActive(false);
        text.GetComponent<Timer>().enabled = true;
    }
}
