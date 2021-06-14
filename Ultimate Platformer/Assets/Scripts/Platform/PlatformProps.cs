using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformProps : MonoBehaviour
{
    public Color normalColor;
    public Color EMPcolor;
    Rigidbody2D rb;
    public bool isStepped = false;
    public bool EMP = false;
    [HideInInspector] public float EMPtimer = 8f;
    public float speed;
    LineRenderer lr;
    GameObject player;
    PlatformAlphabet platformAlphabet;
    private float radius = 6.35f;
    void Start()
    {
        EMPtimer = 8f;
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        platformAlphabet = GetComponent<PlatformAlphabet>();
    }
    
    void Update()
    {
        EMPtimer += Time.deltaTime;
        if(EMPtimer >= 8f)
        {
            EMP = false;
        }
        else
        {
            EMP = true;
        }
        if(EMP)
        {
            rb.velocity = new Vector2(0, 0);
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = EMPcolor;
        }
        else
        {
            rb.velocity = new Vector2(0, 1 * speed);
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = normalColor;
        }
        

        if(lr)
        {
            if(Vector3.Distance(player.transform.position, transform.position) <= radius && !platformAlphabet.hacked)
            {
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, player.transform.position);
            }
            else
            {
                lr.enabled = false;
            }
        }
    }
}
