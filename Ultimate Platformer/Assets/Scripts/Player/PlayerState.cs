using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public bool dead = false;
    private float t = 0;

    void Start()
    {
        dead = false;
        t = 0;
    }
    
    void Update()
    {
        if (dead)
        {
            t += Time.deltaTime;
        }
        if(!dead)
        {
            t = 0;
        }
        if (t >= 3f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
