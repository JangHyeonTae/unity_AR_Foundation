using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;

    [SerializeField] private float playerendPosition =-8f;

    PlayActive _playActive;
    void Start()
    {
        _playActive = GetComponent<PlayActive>();
    }


    void Update()
    {
        if(playerObject.transform.position.y < playerendPosition)
        {
            ReLoadScene();
            _playActive.startButton.SetActive(true);
        }
        
    }

    void ReLoadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

}
