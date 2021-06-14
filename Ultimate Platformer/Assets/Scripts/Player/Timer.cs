using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private float t = 0;
    void Start()
    {
        
    }
    
    void Update()
    {
        t += Time.deltaTime;
        timer.text = "Elapsed time: " + t.ToString("0:00");
    }
}
