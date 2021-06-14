using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EZCameraShake;

public class PlayerHack : MonoBehaviour
{
    public bool invincible = false;
    public bool lowGravity = false;

    public float invincibleTimer = 15f;
    public float lowGravityTimer = 15f;
    public float radius;
    BoxCollider2D boxCollider2D;
    private bool canFall = false;
    public GameObject[] allPlatforms;
    public List<GameObject> allPlatformsNearby;
    private Rigidbody2D rb;
    Passcode passcode;
    PlayerMovement playerMovement;
    public TextMeshProUGUI comboText;

    //sprite
    public Sprite hackedSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        invincibleTimer = 15f;
        lowGravityTimer = 15f;
        passcode = FindObjectOfType<Passcode>();
        InvokeRepeating("GetNearbyPlatforms", 0, 0.02f);
    }
    private void Update()
    {
        invincibleTimer += Time.deltaTime;
        lowGravityTimer += Time.deltaTime;
        comboText.text = "Combo: " + passcode.correctInputAttempts;
        if(invincibleTimer >= 15f)
        {
            invincible = false;
        }
        else
        {
            invincible = true;
        }
        if (lowGravityTimer >= 15f)
        {
            lowGravity = false;
        }
        else
        {
            lowGravity = true;
        }
        if(lowGravity)
        {
            rb.gravityScale = 0.4f;
            playerMovement.jumpForce = 8;
        }
        else
        {
            rb.gravityScale = 10;
            playerMovement.jumpForce = 32;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void GetNearbyPlatforms()
    {
        allPlatforms = GameObject.FindGameObjectsWithTag("Platform");
        if (allPlatformsNearby.Count > 0)
        {
            allPlatformsNearby.Clear();
        }

        if (allPlatforms.Length > 0)
        {
            for (int i = 0; i < allPlatforms.Length; i++)
            {
                if (Vector3.Distance(transform.position, allPlatforms[i].transform.position) <= radius)
                {
                    allPlatformsNearby.Add(allPlatforms[i]);
                }
            }
        }
        if (allPlatformsNearby.Count == 0)
        {
            return;
        }
    }

    // Step on platforms to add score
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Platform")
        {
            GameObject g = collision.collider.gameObject;
            if(!g.GetComponent<PlatformProps>().isStepped)
            {
                if (passcode.correctInputAttempts < 8)
                {
                    Score.i.score += 10;
                }
                if (passcode.correctInputAttempts >= 8 && passcode.correctInputAttempts < 16)
                {
                    Score.i.score += 18;
                }
                if (passcode.correctInputAttempts >= 16 && passcode.correctInputAttempts < 24)
                {
                    Score.i.score += 25;
                }
                if (passcode.correctInputAttempts >= 24)
                {
                    Score.i.score += 40;
                }
                g.GetComponent<PlatformProps>().isStepped = true;
            }
        }
    }

    public bool HackPlatform(string keyPressed)
    {
        for (int i = 0; i < allPlatformsNearby.Count; i++)
        {
            if(allPlatformsNearby[i].GetComponent<PlatformAlphabet>() &&
                allPlatformsNearby[i].GetComponent<PlatformAlphabet>().letter == keyPressed && 
                !allPlatformsNearby[i].GetComponent<PlatformAlphabet>().hacked)
            {
                Debug.Log("Do something");
                passcode.correctInputAttempts++;
                if(passcode.correctInputAttempts == 8 || passcode.correctInputAttempts == 16 || passcode.correctInputAttempts == 24)
                {
                    AudioManager.instance.Play(SoundList.ComboBurst);
                    AudioManager.instance.Play(SoundList.CorrectInput);
                }
                else
                {
                    AudioManager.instance.Play(SoundList.CorrectInput);
                }
                allPlatformsNearby[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = hackedSprite;
                allPlatformsNearby[i].transform.GetChild(1).gameObject.SetActive(false);
                allPlatformsNearby[i].GetComponent<PlatformAlphabet>().hacked = true;
                allPlatformsNearby.Remove(allPlatformsNearby[i]);
                return true;
            }
        }
        AudioManager.instance.Play(SoundList.IncorrectInput);
        CameraShaker.Instance.ShakeOnce(2f, 2f, 0.1f, 1f);
        passcode.correctInputAttempts = 0;
        passcode.pw1Position = 0;
        passcode.pw2Position = 0;
        passcode.pw3Position = 0;
        passcode.debugInput1 = "";
        passcode.debugInput2 = "";
        passcode.debugInput3 = "";
        Debug.Log("Cant check");
        return false;
    }

    public void EMPattack()
    {
        for(int i = 0; i < allPlatforms.Length; i++)
        {
            allPlatforms[i].GetComponent<PlatformProps>().EMPtimer = 0;
        }
    }
}
