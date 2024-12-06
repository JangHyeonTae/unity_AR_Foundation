using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float _Sec;
    int _min;

    [SerializeField] TextMeshProUGUI _text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MSTimer();
    }

    void MSTimer()
    {
        _Sec += Time.deltaTime;
        _text.text = string.Format("{0:D2}:{1:D2}", _min, (int)_Sec);

        if((int)_Sec > 59)
        {
            _Sec = 0;
            _min++;
        }
    }
}
